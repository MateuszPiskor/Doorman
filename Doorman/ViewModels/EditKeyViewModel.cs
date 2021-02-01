using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System.Windows.Input;
using Key = Doorman.Model.Key;

namespace Doorman.ViewModels
{
    public class EditKeyViewModel : NotficationErrorBaseClass, IEditKeyViewModel
    {
        #region private members
        private KeyEditModelWrapper keyEditWrapper;

        public KeyEditModelWrapper KeyEditModelWrapper
        {
            get { return keyEditWrapper; }
            set { keyEditWrapper = value; }
        }
        
        private IKeyRepository _keyRepository;
        ICommand addKey;
        #endregion
        #region properties
        
       
        public ICommand SearchKey
        {
            get
            {
                if (addKey == null)
                {
                    addKey = new RelayCommand(
                       (object o) =>
                       {
                          var key = _keyRepository.GetById(KeyEditModelWrapper.Id);
                           base.OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return KeyEditModelWrapper != null && !KeyEditModelWrapper.HasErrors;
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
            keyEditWrapper = new KeyEditModelWrapper(new KeyEditModel());
        }
        #endregion
        #region privatemethods
        #endregion
    }
}
