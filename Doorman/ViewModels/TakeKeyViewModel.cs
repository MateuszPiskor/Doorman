using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Key = Doorman.Model.Key;

namespace Doorman.ViewModels
{
    public class TakeKeyViewModel : NotficationErrorBaseClass, ITakeKeyViewModel
    {
        #region private members
        private IKeyInUseRepository _keyInUseReposiotory;
        private IKeyRepository _keyRepository;
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
                         bool keyExist = true;
                         Model.Key Key = _keyRepository.GetIdByRoomNumber(TakeKeyModelWrapper.KeyNumber);
                         if (Key == null)
                         {
                             keyExist = false;
                         }

                         KeyInUse keyInUse = _keyInUseReposiotory.GetByKeyId(Key.Id);

                         bool keyInUsing = keyInUse != null;
                         bool keyBelongsToThisEmployee = false;

                         if (!keyInUsing)
                         {
                             messageBoxList.Add("Nikt nie pobierał klucza o tym numerze.");
                             TakeKeyModelWrapper.KeyNumber = "";
                         }
                         else
                         {
                             keyBelongsToThisEmployee = isKeyBelongsToThisEmploye(keyInUse);
                             messageBoxList.Add($"Nie możesz zdać tego klucza\nKlucz ten został porzyczony przez {keyInUse.Employee.FirstName},{keyInUse.Employee.LastName}, {keyInUse.Employee.Department}\nMusi zostać zdany przez tą osobę"
                                 );
                             TakeKeyModelWrapper.KeyNumber = "";
                         }

                         if (keyExist && keyInUsing && keyBelongsToThisEmployee)
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
        public TakeKeyViewModel(IKeyInUseRepository keyInUseReposiotory, TakeKeyWrapper takeKeyWrapper, IKeyRepository keyRepository)
        {
            _keyInUseReposiotory = keyInUseReposiotory;
            _keyRepository = keyRepository;
            TakeKeyModelWrapper = takeKeyWrapper;
            messageBoxList = new List<string>();
        }
        #endregion
        #region privatemethods
        private void ClearForm()
        {
            TakeKeyModelWrapper.FirstName = "";
            TakeKeyModelWrapper.LastName = "";
            TakeKeyModelWrapper.KeyNumber = "";
        }
        private bool IsDataCorrect()
        {
            if (!string.IsNullOrEmpty(TakeKeyModelWrapper.FirstName) && !string.IsNullOrEmpty(TakeKeyModelWrapper.LastName) && TakeKeyModelWrapper.KeyNumber != "")
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
