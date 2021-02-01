using Doorman.DataServices;
using Doorman.Wrappers;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class RemoveKeyViewModel : NotficationErrorBaseClass, IRemoveKeyViewModel
    {
        public RemoveKeyViewModel(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
            KeyRoom = new KeyWrapper(new Model.Key());
        }

        private string roomNameVisiblity= "Collapsed";
        private string keyText= "Szukaj klucza";

        public string KeyText
        {
            get { return keyText; }
            set { keyText = value;
                OnPropertyChange();
            }
        }

        private KeyWrapper keyRoom;

        public string RoomNameVisiblity
        {
            get { return roomNameVisiblity; }
            set { roomNameVisiblity = value;
                OnPropertyChange();
            }
        }


        public KeyWrapper KeyRoom
        {
            get { return keyRoom; }
            set
            {
                keyRoom = value;
                OnPropertyChange();
            }
        }

        private ICommand removeKey;
        private IKeyRepository _keyRepository;

        public ICommand RemoveKey
        {
            get
            {
                if (removeKey == null)
                {
                    removeKey = new RelayCommand(
                       (object o) =>
                       {
                           Model.Key Key =_keyRepository.GetKeyByRoomNumber(KeyRoom.RoomNumber);
                           bool keyExist = Key != null;
                           
                           if (keyExist && RoomNameVisiblity== "Collapsed")
                           {
                               RoomNameVisiblity = "Visible";
                               KeyRoom.RoomName = _keyRepository.GetRoomNameByRoomNumber(KeyRoom.RoomNumber);
                               KeyText = "Usuń klucz"; 
                               keyExist = true;
                           }
                           else if(keyExist && RoomNameVisiblity== "Visible")
                           {
                               _keyRepository.Remove(Key);
                               MessageBox.Show("Klucz został usunięty");
                               KeyRoom.RoomNumber = "";
                               RoomNameVisiblity = "Collapsed";
                               KeyText = "Szukaj klucza";
                           }
                           else
                           {
                               MessageBox.Show("Klucz nie istnieje w bazie. Proszę popraw jego numer","Informacja");
                               KeyRoom.RoomNumber = "";
                           }
                       },
                       (object o) =>
                       {
                           return KeyRoom != null && !KeyRoom.HasErrors;
                       });
                }

                return removeKey;
            }
        }
    }
}
