using Doorman.DataServices;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class AddNewKeyViewModel : ViewModelBase, IAddNewKeyViewModel
    {
        #region private members
        private Model.Key key = new Model.Key();
        private IKeyRepository _keyDataSerivce;
        private bool isKeyValid()
        {
            if (key.RoomNumber != 0 && key.RoomName != "")
            {
                return true;
            }
            return false;
        }
        ICommand addKey;
        #endregion
        #region properties
        public int RoomNumber
        {
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
        public ICommand AddKey
        {
            get
            {
                if (addKey == null)
                {
                    addKey = new RelayCommand(
                       (object o) =>
                       {
                           _keyDataSerivce.AddKey(key);
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

            _keyDataSerivce = keyDataService;
        }
        #endregion
        #region privatemethods
        #endregion
    }
}
