using Doorman.DataServices;
using Doorman.Wrappers;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class RemoveKeyViewModel : NotficationErrorBaseClass, IRemoveKeyViewModel
    {
        public RemoveKeyViewModel(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
            Key = new KeyWrapper(new Model.Key());
        }
        private KeyWrapper keyWrapper;

        public KeyWrapper Key
        {
            get { return keyWrapper; }
            set
            {
                keyWrapper = value;
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
                           Model.Key keyFound = _keyRepository.GetById(Key.Id);
                           base.OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return Key != null && !Key.HasErrors;
                       });
                }

                return removeKey;
            }
        }
    }
}
