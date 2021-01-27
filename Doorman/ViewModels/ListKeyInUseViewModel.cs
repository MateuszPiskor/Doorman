using Doorman.DataServices;
using Doorman.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.ViewModels
{
    class ListKeyInUseViewModel : ViewModelBase, IListKeyInUseViewModel
    {
        private IKeyInUseRepository _keyInUseRepository;

        public ListKeyInUseViewModel(IKeyInUseRepository keyInUseRepository)
        {
            _keyInUseRepository = keyInUseRepository;
            LoadAsync();
        }
        public async Task LoadAsync()
        {
            IEnumerable<Model.KeyInUse> keysInUse = await _keyInUseRepository.GetAllAsync();
            KeysInUse.Clear();
            foreach (var item in keysInUse)
            {
                KeysInUse.Add(item);
            }
        }

        public ObservableCollection<KeyInUse> KeysInUse { get; } = new ObservableCollection<KeyInUse>();
    }
}
