using Doorman.DataServices;
using Doorman.Wrappers;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class AddNewKeyViewModel : ViewModelBase, IAddNewKeyViewModel
    {
        #region private members

        private KeyWrapper keyWrapper;
        private IKeyRepository _keyDataSerivce;
        private bool isKeyValid()
        {
            if (keyWrapper.RoomNumber != 0 && keyWrapper.RoomName != "")
            {
                return true;
            }
            return false;
        }
        ICommand addKey;
        #endregion
        #region properties
        public KeyWrapper Key {
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
                           _keyDataSerivce.AddKey(keyWrapper.Model);
                           base.OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return isKeyValid();
                       });
                }

                return addKey;
            }
        }
        #endregion
        #region costructors
        public AddNewKeyViewModel(IKeyRepository keyDataService)
        {
            //Keys = new ObservableCollection<Key>();
            keyWrapper = new KeyWrapper(new Model.Key());
            _keyDataSerivce = keyDataService;
        }
        #endregion
        #region privatemethods
        #endregion
    }
}
