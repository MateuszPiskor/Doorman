using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class TakeKeyViewModel : NotficationErrorBaseClass, ITakeKeyViewModel
    {
        #region private members
        private IKeyInUseRepository _keyInUseReposiotory;
        private ICommand takeKey;
        private List<string> messageBoxList;

        #endregion
        #region properties
        public TakeKeyWrapper TakeKeyModelWrapper { get; set; }
        public ICommand TakeKey
        {
            get
            {
                if (takeKey == null)
                {
                    takeKey = new RelayCommand(
                     (object o) =>
                     {
                         messageBoxList.Clear();
                         KeyInUse keyInUse = _keyInUseReposiotory.GetByKeyId(TakeKeyModelWrapper.KeyNumber);
                         bool keyExist = keyInUse != null;
                         bool keyBelongsToThisEmployee = false;

                         if (!keyExist)
                         {
                             messageBoxList.Add("Taki klucz o takim numerze nie został porzyczony.");
                             TakeKeyModelWrapper.KeyNumber = 0;
                         }
                         else
                         {
                             keyBelongsToThisEmployee = isKeyBelongsToThisEmploye(keyInUse);
                             messageBoxList.Add($"Nie możesz zdać tego klucza\nKlucz ten został porzyczony przez {keyInUse.Employee.FirstName},{keyInUse.Employee.LastName}, {keyInUse.Employee.Department}\nMusi zostać zdany przez tą osobę"
                                 );
                             TakeKeyModelWrapper.KeyNumber = 0;
                         }

                         if (keyExist && keyBelongsToThisEmployee)
                         {
                             _keyInUseReposiotory.Remove(keyInUse);
                             MessageBox.Show("Klucz został usniety z bazy", "Informacja");
                             ClearForm();
                         }
                         else
                         {
                             ShowAllMessage(messageBoxList);
                         }

                     },
                     (object o) =>
                     {
                         return IsDataCorrect() && TakeKeyModelWrapper != null && !TakeKeyModelWrapper.HasErrors;
                     });
                }
                return takeKey;
            }
        }

        #endregion
        #region costructors
        public TakeKeyViewModel(IKeyInUseRepository keyInUseReposiotory, TakeKeyWrapper takeKeyWrapper)
        {
            _keyInUseReposiotory = keyInUseReposiotory;
            TakeKeyModelWrapper = takeKeyWrapper;
            messageBoxList = new List<string>();
        }
        #endregion
        #region privatemethods
        private void ClearForm()
        {
            TakeKeyModelWrapper.FirstName = "";
            TakeKeyModelWrapper.LastName = "";
            TakeKeyModelWrapper.KeyNumber = 0;
        }
        private bool IsDataCorrect()
        {
            if (!string.IsNullOrEmpty(TakeKeyModelWrapper.FirstName) && !string.IsNullOrEmpty(TakeKeyModelWrapper.LastName) && TakeKeyModelWrapper.KeyNumber != 0)
            {
                return true;
            }

            return false;
        }

        private bool isKeyBelongsToThisEmploye(KeyInUse keyInUse)
        {
            return keyInUse.Employee.FirstName == TakeKeyModelWrapper.FirstName && keyInUse.Employee.LastName == TakeKeyModelWrapper.LastName ? true : false;
            //var keyInUse = _keyInUseReposiotory.GetEmployeeKey(TakeKeyModelWrapper);
        }

        private void ShowAllMessage(List<string> messageBoxList)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < messageBoxList.Count; i++)
            {
                sb.Append($"{i + 1}. {messageBoxList[i]}\n");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Informacja");
            }
        }
        #endregion
    }

}
