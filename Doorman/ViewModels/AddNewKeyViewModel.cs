using Doorman.DataServices;
using Doorman.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class AddNewKeyViewModel : NotficationErrorBaseClass, IAddNewKeyViewModel
    {
        #region costructors
        public AddNewKeyViewModel(IKeyRepository keyDataService)
        {
            keyWrapper = new KeyWrapper(new Model.Key());
            _keyRepository = keyDataService;
            messageBoxList = new List<string>();
        }
        #endregion
        #region private members
        private KeyWrapper keyWrapper;
        private IKeyRepository _keyRepository;
        private List<string> messageBoxList;
        ICommand addKey;

        #endregion
        #region properties
        public KeyWrapper KeyWrapper
        {
            get
            {
                return keyWrapper;
            }
            set
            {
                keyWrapper = value;
                OnPropertyChange();
            }
        }
        public ICommand AddKey
        {
            get
            {
                if (addKey == null)
                {
                    addKey = new RelayCommand(
                       (object o) =>
                       {
                           messageBoxList.Clear();
                           if (_keyRepository.GetKeyByRoomNumber(keyWrapper.RoomNumber) == null)
                           {
                               _keyRepository.Add(new Model.Key() { RoomName = KeyWrapper.RoomName, RoomNumber = KeyWrapper.RoomNumber });
                               _keyRepository.SaveAsync();
                               messageBoxList.Add("Klucz został dodany do bazy");
                               keyWrapper.RoomNumber = "";
                               keyWrapper.RoomName = "";
                               ShowAllMessage(messageBoxList);
                           }
                           else
                           {
                               messageBoxList.Add("Klucz o podanym id istnieje już w bazie. Podaj nowe poprowane id");
                               keyWrapper.RoomNumber = "";
                               ShowAllMessage(messageBoxList);
                           }

                           base.OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return IsFilled() && KeyWrapper != null && !keyWrapper.HasErrors;
                       });
                }

                return addKey;
            }
        }

        #endregion
        #region privatemethods
        private bool IsFilled()
        {
            if (keyWrapper.RoomNumber != null && keyWrapper.RoomName != null)
            {
                return true;
            }
            return false;
        
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
