using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class RemoveEmployeeViewModel : NotficationErrorBaseClass, IRemoveEmployeeViewModel
    {
        public RemoveEmployeeViewModel(IEmployeeRepository keyRepository)
        {
            _employeeRepository = keyRepository;
            Employee = new EmployeeWrapper(new Employee());
        }

        private string employeeNameVisiblity = "Collapsed";
        private string buttonText = "Szukaj pracownika";

        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                OnPropertyChange();
            }
        }

        private EmployeeWrapper employee;

        public string EmployeeNameVisiblity
        {
            get { return employeeNameVisiblity; }
            set
            {
                employeeNameVisiblity = value;
                OnPropertyChange();
            }
        }


        public EmployeeWrapper Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChange();
            }
        }

        private ICommand removeEmployee;
        private IEmployeeRepository _employeeRepository;

        public ICommand RemoveEmployee
        {
            get
            {
                if (removeEmployee == null)
                {
                    removeEmployee = new RelayCommand(
                       (object o) =>
                       {
                           System.Console.WriteLine("ok");
                           //Model.Key Key = _employeeRepository.GetKeyByRoomNumber(Employee.RoomNumber);
                           //bool keyExist = Key != null;

                           //if (keyExist && EmployeeNameVisiblity == "Collapsed")
                           //{
                           //    EmployeeNameVisiblity = "Visible";
                           //    Employee.RoomName = _employeeRepository.GetRoomNameByRoomNumber(Employee.RoomNumber);
                           //    ButtonText = "Usuń klucz";
                           //    keyExist = true;
                           //}
                           //else if (keyExist && EmployeeNameVisiblity == "Visible")
                           //{
                           //    _employeeRepository.Remove(Key);
                           //    MessageBox.Show("Klucz został usunięty");
                           //    Employee.RoomNumber = "";
                           //    EmployeeNameVisiblity = "Collapsed";
                           //    ButtonText = "Szukaj pracownika";
                           //}
                           //else
                           //{
                           //    MessageBox.Show("Klucz nie istnieje w bazie. Proszę popraw jego numer", "Informacja");
                           //    Employee.RoomNumber = "";
                           //}
                       },
                       (object o) =>
                       {
                           return Employee != null && !Employee.HasErrors;
                       });
                }

                return removeEmployee;
            }
        }
    }
}
