using Doorman.DataServices;
using Doorman.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Doorman.ViewModels
{
    class ListKeyInUseViewModel : ViewModelBase, IListKeyInUseViewModel
    {
        #region private members
        private IKeyInUseRepository _keyInUseRepository;
        #endregion
        #region properties
        public ListKeyInUseViewModel(IKeyInUseRepository keyInUseRepository)
        {
            _keyInUseRepository = keyInUseRepository;
            LoadAsync();
        }
        public ObservableCollection<KeyInUse> KeysInUse { get; } = new ObservableCollection<KeyInUse>();
        #endregion
        #region costructors
        #endregion
        #region privatemethods
        #endregion
        #region public methods
        public async Task LoadAsync()
        {
            IEnumerable<Model.KeyInUse> keysInUse = await _keyInUseRepository.GetAllAsync();
            KeysInUse.Clear();
            foreach (var item in keysInUse)
            {
                KeysInUse.Add(item);
            }
        }
        #endregion
    }
}
