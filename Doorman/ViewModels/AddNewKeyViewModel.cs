using Doorman.DataServices;
using Doorman.Wrappers;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class AddNewKeyViewModel : NotficationErrorBaseClass, IAddNewKeyViewModel
    {
        #region private members
        private KeyWrapper keyWrapper;
        private IKeyRepository _keyDataSerivce;
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
                           return IsFilled();
                       });
                }

                return addKey;
            }
        }

        #endregion
        #region costructors
        public AddNewKeyViewModel(IKeyRepository keyDataService)
        {
            keyWrapper = new KeyWrapper(new Model.Key());
            _keyDataSerivce = keyDataService;
        }
        #endregion
        #region privatemethods
        private bool IsFilled()
        {
            if (keyWrapper.RoomNumber != 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
