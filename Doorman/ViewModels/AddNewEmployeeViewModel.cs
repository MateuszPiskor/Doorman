using Doorman.DataServices;
using Doorman.Helpers;
using Doorman.Model;
using Doorman.Views;
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

        private IEmployeeRepository _employeeRepository;

        private string initialId;

        public string InitialId
        {
            get { return initialId; }
            set { initialId = value;
                OnPropertyChange();
            }
        }

        private bool isModelCorrect;

        public bool IsModelCorrect
        {
            get { return isModelCorrect; }
            set { isModelCorrect = value; }
        }


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

        public AddNewEmployeeViewModel(IEmployeeRepository employeeDataService)
        {
            _employeeRepository = employeeDataService;
            int id = _employeeRepository.GetLastEntity().Id;
            InitialId = id.InitialNextIdWithZeros();

        }

        ICommand addEmployee;

        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null) addEmployee = new RelayCommand(
                       (object o) =>
                       {
                           _employeeRepository.Add(employee);
                           
                           _employeeRepository.SaveAsync();
                           OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return checkModel();
                       });
                return addEmployee;
            }
        }

        private bool checkModel()
        {
            if (employee.FirstName != "" && employee.LastName != "" && employee.Position!="" && employee.Department!="")
            {
                isModelCorrect = true;
                return true;
            }
            return false;
        }
    }
}
