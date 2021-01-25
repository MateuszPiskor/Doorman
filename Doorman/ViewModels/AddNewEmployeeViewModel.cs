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
    class AddNewEmployeeViewModel : ViewModelBase, IAddNewEmployeeViewModel
    {
        private Employee employee = new Employee();

        private IEmployeeDataService _employeeDataSerivce;

        public string FirstName
        {
            get
            {
                return employee.FirstName;
            }
            set
            {
                employee.FirstName = value;
                OnPropertyChange(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return employee.LastName;
            }
            set
            {
                employee.LastName = value;
                OnPropertyChange(nameof(LastName));
            }
        }
        public string Department
        {
            get
            {
                return employee.Department;
            }
            set
            {
                employee.Department = value;
                OnPropertyChange(nameof(Department));
            }
        }
        public string Position
        {
            get
            {
                return employee.Position;
            }
            set
            {
                employee.Position = value;
                OnPropertyChange(nameof(Position));
            }
        }

        public AddNewEmployeeViewModel(IEmployeeDataService employeeDataService)
        {
            _employeeDataSerivce = employeeDataService;
        }

        ICommand addEmployee;

        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null) addEmployee = new RelayCommand(
                       (object o) =>
                       {
                           _employeeDataSerivce.AddEmployee(employee);
                           OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return true;
                       });
                return addEmployee;
            }
        }
    }
}
