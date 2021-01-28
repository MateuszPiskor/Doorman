using Doorman.DataServices;
using Doorman.Helpers;
using Doorman.Model;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    class AddNewEmployeeViewModel : ViewModelBase, IAddNewEmployeeViewModel
    {
        #region private members
        private Employee employee = new Employee();

        private IEmployeeRepository _employeeRepository;

        private string initialId;
        private bool isModelCorrect;
        ICommand addEmployee;
        #endregion
        #region properties
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
        public string InitialId
        {
            get { return initialId; }
            set
            {
                initialId = value;
                OnPropertyChange();
            }
        }
        public bool IsModelCorrect
        {
            get { return isModelCorrect; }
            set { isModelCorrect = value; }
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
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(
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
                }

                return addEmployee;
            }
        }
        #endregion
        #region costructors
        public AddNewEmployeeViewModel(IEmployeeRepository employeeDataService)
        {
            _employeeRepository = employeeDataService;
            int id = _employeeRepository.GetLastEntity() == null ? 0 : _employeeRepository.GetLastEntity().Id;
            InitialId = id.InitialNextIdWithZeros();

        }
        #endregion
        #region privatemethods
        private bool checkModel()
        {
            if (employee.FirstName != "" && employee.LastName != "" && employee.Position != "" && employee.Department != "")
            {
                isModelCorrect = true;
                return true;
            }
            return false;
        }
        #endregion
    }
}
