using Doorman.DataServices;
using Doorman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class TakeKeyViewModel: ViewModelBase,ITakeKeyViewModel
    {
        public TakeKeyViewModel(IKeyDataService keyDataSerive, IEmployeeRepository employeeDataService, IKeyInUseRepository keyInUseReposiotory)
        {
            _keyDataService = keyDataSerive;
            _employeeDataService = employeeDataService;
            _keyInUseReposiotory = keyInUseReposiotory;
        }
        private string firstName;
        private string lastName;
        private int keyNumber;
        private IKeyDataService _keyDataService;
        private IEmployeeRepository _employeeDataService;
        private IKeyInUseRepository _keyInUseReposiotory;
        KeyInUse keyInUse = new KeyInUse();

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChange();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;

            }
        }

        public int KeyNumber
        {
            get { return keyNumber; }
            set
            {
                keyNumber = value;

            }
        }

        private ICommand takeKey;

        public ICommand TakeKey
        {
            get
            {
                if (takeKey == null) takeKey = new RelayCommand(
                     (object o) =>
                     {
                         //keyInUse.KeyId = keyNumber;
                         int employeeId = _employeeDataService.GetUserId(FirstName, LastName);
                         //keyInUse.EmployeeId = EmployeeId;
                         keyInUse.Id = _keyInUseReposiotory.GetKeyinUseId(keyNumber,employeeId);
                         var keytoRemove = _keyInUseReposiotory.GetByIdAsync(keyInUse.Id).Result;
                      
                         _keyInUseReposiotory.Remove(keytoRemove);
                         _keyInUseReposiotory.SaveAsync();
                         base.OnPropertyChange();

                     },
                     (object o) =>
                     {
                         return IsDataCorrect();
                         //if (key.RoomNumber != 0 && key.RoomName != "")
                         //{
                         //    return true;
                         //}
                         //return false;
                     });
                return takeKey;
            }

        }

        private bool IsDataCorrect()
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && keyNumber != 0)
            {
                return true;
            }

            return false;
        }
    

    }

}
