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
        public GiveKeyViewModel(IKeyDataService keyDataSerive, IEmployeeRepository employeeDataService )
        {
            _keyDataService = keyDataSerive;
            _employeeDataService = employeeDataService;
        }
        private string firstName;
        private string lastName;
        private int keyNumber;
        private IKeyDataService _keyDataService;
        private IEmployeeRepository _employeeDataService;
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
                         IEnumerable<Employee> employees= _employeeDataService.GetAll();
                         IEnumerable<Employee> duplicateEmployees = _employeeDataService.FindEmployees(employees, firstName, lastName);
                         if (duplicateEmployees.Count() == 1){
                             _keyDataService.AddGiveKey(keyInUse);
                             OnPropertyChange();
                         }
                     },
                     (object o) =>
                     {
                         if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && keyNumber != 0)
                         {
                             return true;
                         }
                         
                         return false;
                         //if (key.RoomNumber != 0 && key.RoomName != "")
                         //{
                         //    return true;
                         //}
                         //return false;
                     });
                return giveKey;
            }
           
        }


    }
}
