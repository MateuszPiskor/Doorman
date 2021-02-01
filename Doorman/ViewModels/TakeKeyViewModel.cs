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
                         //TO DO class to validate in correct way
                         messageBoxList.Clear();
                         bool keyExist = false;
                         bool keyIsInUse = false;
                         bool keyBelongToThisPerson = false;
                         KeyInUse keyInUse = null;
                         
                         var key = _keyRepository.GetKeyByRoomNumber(TakeKeyModelWrapper.KeyNumber);
                         if (key != null)
                             keyExist = true;
                         else
                         {
                             messageBoxList.Add("Klucz nie istnieje w bazie");
                             ClearForm();
                         }

                         if (keyExist)
                         {
                             keyInUse = _keyInUseReposiotory.GetByKeyId(key.Id);
                             if (keyInUse != null)
                                 keyIsInUse = true;
                             else
                             {
                                 messageBoxList.Add("Klucz istnieje w bazie ale nikt go nie pobierał.");
                                 ClearForm();
                             }
                         }
                         
                         if (keyExist && keyIsInUse)
                             keyBelongToThisPerson = isKeyBelongsToThisEmploye(keyInUse);

                         if (keyExist && keyIsInUse && keyBelongToThisPerson)
                         {
                             _keyInUseReposiotory.Remove(keyInUse);
                             _keyInUseReposiotory.SaveAsync();
                             MessageBox.Show("Klucz został usniety z bazy", "Informacja");
                             ClearForm();
                         }
                         else
                         {
                             ShowAllMessage(messageBoxList);
                             ClearForm();
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
            if (!string.IsNullOrEmpty(TakeKeyModelWrapper.FirstName) && !string.IsNullOrEmpty(TakeKeyModelWrapper.LastName) && TakeKeyModelWrapper.KeyNumber != null)
            {
                return true;
            }

            return false;
        }

        private bool isKeyBelongsToThisEmploye(KeyInUse keyInUse)
        {
            return keyInUse.Employee.FirstName == TakeKeyModelWrapper.FirstName && keyInUse.Employee.LastName == TakeKeyModelWrapper.LastName ? true : false;
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
