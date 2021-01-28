using Doorman.DataServices;
using Doorman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Key = Doorman.Model.Key;

namespace Doorman.ViewModels
{
    public class EditKeyViewModel: ViewModelBase, IEditKeyViewModel
    {
        Key key= new Key();

        private Key keyFound;

        public Key KeyForund
        {
            get { return keyFound; }
            set { keyFound = value;
                OnPropertyChange();

            }
        }


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChange();
            }
        }

        public EditKeyViewModel(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
        }

        ICommand addKey;
        private IKeyRepository _keyRepository;

        public ICommand SearchKey
        {
            get
            {
                if (addKey == null) addKey = new RelayCommand(
                       (object o) =>
                       {
                           keyFound = _keyRepository.GetByIdAsync(id).Result;
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
                return addKey;
            }
        }
    }
}
