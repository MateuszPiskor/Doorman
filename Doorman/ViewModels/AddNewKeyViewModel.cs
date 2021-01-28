using Doorman.DataServices;
using Doorman.Model;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class AddNewKeyViewModel: ViewModelBase,IAddNewKeyViewModel
    {
        private Model.Key key= new Model.Key();

        private IKeyRepository _keyDataSerivce;
        
        public int RoomNumber {
            get
            {
                return key.RoomNumber;
            }
            set 
            {
                key.RoomNumber = value;
                OnPropertyChange(nameof(RoomNumber));
            } 
        }

        public string RoomName
        {
            get
            {
                return key.RoomName;
            }
            set
            {
                key.RoomName = value;
                OnPropertyChange(nameof(RoomName));
            }
        }

        public AddNewKeyViewModel(IKeyRepository keyDataService)
        {
            //Keys = new ObservableCollection<Key>();

            _keyDataSerivce = keyDataService;
        }
        
        ICommand addKey;

        public ICommand AddKey 
        {
            get
            {
                if (addKey == null) addKey = new RelayCommand(
                       (object o) =>
                       {
                           _keyDataSerivce.AddKey(key);
                           base.OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return isKeyValid();
                       });
                return addKey;
            }
        }

        private bool isKeyValid()
        {
            if (key.RoomNumber != 0 && key.RoomName != "")
            {
                return true;
            }
            return false;
        }

    }
}
