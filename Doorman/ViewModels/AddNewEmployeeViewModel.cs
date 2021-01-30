using Doorman.DataServices;
using Doorman.Helpers;
using Doorman.Model;
using Doorman.Wrappers;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    class AddNewEmployeeViewModel : NotficationErrorBaseClass, IAddNewEmployeeViewModel
    {
        #region private members
        private EmployeeWrapper _employee = new EmployeeWrapper(new Employee());
        private IEmployeeRepository _employeeRepository;
        private string initialId;
        private bool isModelCorrect;
        ICommand addEmployee;
        #endregion
        #region properties
        public EmployeeWrapper Employee
        {
            get { return _employee; }
            private set
            {
                _employee = value;
                OnPropertyChange();
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
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(
                       (object o) =>
                       {
                           _employeeRepository.Add(_employee.Model);

                           _employeeRepository.SaveAsync();
                           OnPropertyChange();
                       },
                       (object o) =>
                       {
                           return AreAllPropertiesFielled() && Employee != null && !Employee.HasErrors;
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
        private bool AreAllPropertiesFielled()
        {
            if (_employee.FirstName == null || _employee.LastName == null || _employee.Position == null || _employee.Department == null)
            {

                return false;
            }
            return true;
        }
        #endregion
    }
}
