using Doorman.DataServices;
using System.Windows.Input;
using Key = Doorman.Model.Key;

namespace Doorman.ViewModels
{
    public class EditKeyViewModel : ViewModelBase, IEditKeyViewModel
    {
        #region private members
        Key key = new Key();
        private Key keyFound;
        private int id;
        private IKeyRepository _keyRepository;
        ICommand addKey;
        #endregion
        #region properties
        public Key KeyForund
        {
            get { return keyFound; }
            set
            {
                keyFound = value;
                OnPropertyChange();

            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange();
            }
        }
        public ICommand SearchKey
        {
            get
            {
                if (addKey == null)
                {
                    addKey = new RelayCommand(
                       (object o) =>
                       {
                           keyFound = _keyRepository.GetById(id);
                           base.OnPropertyChange();
                       },
                       (object o) =>
                       {
                           if (id > 1 && id < 9999)
                           {
                               return true;
                           }
                           return false;
                       });
                }

                return addKey;
            }
        }
        #endregion
        #region costructors
        public EditKeyViewModel(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
        }
        #endregion
        #region privatemethods
        #endregion
    }
}
