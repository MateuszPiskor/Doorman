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
    public class GiveKeyViewModel:ViewModelBase, IGiveKeyViewModel
    {
        public GiveKeyViewModel(IKeyRepository keyDataSerive, IEmployeeRepository employeeDataService, IKeyInUseRepository keyInUseReposiotory)
        {
            _keyDataService = keyDataSerive;
            _employeeDataService = employeeDataService;
            _keyInUseReposiotory = keyInUseReposiotory;
        }
        private string firstName;
        private string lastName;
        private int keyNumber;
        private IKeyRepository _keyDataService;
        private IEmployeeRepository _employeeDataService;
        private IKeyInUseRepository _keyInUseReposiotory;
        KeyInUse keyInUse= new KeyInUse();

        public string FirstName
        {
            get { return firstName; }
            set { 
                firstName = value;
                OnPropertyChange();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set { 
                lastName = value;

            }
        }

        public int KeyNumber
        {
            get { return keyNumber; }
            set { 
                keyNumber = value;

            }
        }

        private ICommand giveKey;

        public ICommand GiveKey
        {
            get {
                if (giveKey == null) giveKey = new RelayCommand(
                     (object o) =>
                     {
                         keyInUse.KeyId = keyNumber;
                         int EmployeeId= _employeeDataService.GetUserId(FirstName, LastName);
                         keyInUse.EmployeeId = EmployeeId;
                         _keyInUseReposiotory.Add(keyInUse);
                         _keyInUseReposiotory.SaveAsync();
                         base.OnPropertyChange();
                         
                     },
                     (object o) =>
                     {
                         return IsDataCorrect();
                     });
                return giveKey;
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
