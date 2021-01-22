using Doorman.DataServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.ViewModels
{
    public class AddNewKeyViewModel: ViewModelBase
    {
        //private Key _selectedKey;
        private readonly IKeyDataService keysDataSerivce;



        //public ObservableCollection<Key> Keys { get; set; }

        //public Key SelectedKey
        //{
        //    get
        //    {
        //        return _selectedKey;
        //    }
        //    set
        //    {
        //        _selectedKey = value;
        //        OnPropertyChange();
        //    }
        //}
        public AddNewKeyViewModel(IKeyDataService keysDataService)
        {
            //Keys = new ObservableCollection<Key>();
            this.keysDataSerivce = keysDataService;
        }


        //public void Load()
        //{
        //    var keyss = keysDataSerivce.GetAll();

        //    Firts clear the list to ensure that duplicates won`t occur
        //    Keys.Clear();
        //    foreach (var keys in keyss)
        //    {
        //        Keys.Add(keys);
        //    }
        //}
    }
}
