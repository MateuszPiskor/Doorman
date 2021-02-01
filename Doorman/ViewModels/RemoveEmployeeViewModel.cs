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
                           int id= int.Parse(Employee.IdAsAString);
                           Employee employee = _employeeRepository.GetById(id);
                           bool employeeExist = employee != null;
                           //bool keyExist = Key != null;

                           if (employeeExist && EmployeeNameVisiblity == "Collapsed")
                           {
                               EmployeeNameVisiblity = "Visible";
                               Employee.FirstName = employee.FirstName;
                               Employee.LastName = employee.LastName;
                               Employee.Department = employee.Department;
                               Employee.Position = employee.Positon;
                               //Employee.RoomName = _employeeRepository.GetRoomNameByRoomNumber(Employee.RoomNumber);
                               ButtonText = "Usuń pracownika";
                               //employeeExist = true;
                           }
                           else if (employeeExist && EmployeeNameVisiblity == "Visible")
                           {
                               _employeeRepository.Remove(employee);
                               MessageBox.Show("Pracownik został usunięty");
                               Employee.FirstName = "";
                               Employee.LastName = "";
                               Employee.Department = "";
                               Employee.Position = "";
                               EmployeeNameVisiblity = "Collapsed";
                               ButtonText = "Szukaj pracownika";
                           }
                           else
                           {
                               MessageBox.Show("Pracownik nie istnieje w bazie. Popraw jego numer ID", "Informacja");
                               Employee.IdAsAString = "";
                               EmployeeNameVisiblity = "Collapsed";
                           }
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
