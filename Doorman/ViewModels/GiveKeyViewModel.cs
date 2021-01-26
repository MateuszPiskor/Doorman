using Doorman.DataServices;
using Doorman.Model;
using DoorMan.DataAccess.Entities;
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
        public GiveKeyViewModel(IKeyDataService keyDataSerive, IEmployeeDataService employeeDataService )
        {
            _keyDataService = keyDataSerive;
            _employeeDataService = employeeDataService;
        }
        private string firstName;
        private string lastName;
        private int keyNumber;
        private IKeyDataService _keyDataService;
        private IEmployeeDataService _employeeDataService;
        GiveKeyModel giveKeyModel= new GiveKeyModel();

        public string FirstName
        {
            get { return firstName; }
            set { 
                giveKeyModel.FirstName = value;
                OnPropertyChange();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set { 
                giveKeyModel.LastName = value;

            }
        }

        public int KeyNumber
        {
            get { return keyNumber; }
            set { 
                giveKeyModel.KeyNumber = value;

            }
        }

        private ICommand giveKey;

        public ICommand GiveKey
        {
            get {
                if (giveKey == null) giveKey = new RelayCommand(
                     (object o) =>
                     {
                         IEnumerable<EmployeeEnitity> employees= _employeeDataService.GetAll();
                         IEnumerable<EmployeeEnitity> duplicateEmployees = _employeeDataService.FindEmployees(employees, giveKeyModel.FirstName, giveKeyModel.LastName);
                         if (duplicateEmployees.Count() == 1){
                             _keyDataService.AddGiveKey(giveKeyModel);
                             OnPropertyChange();
                         }
                     },
                     (object o) =>
                     {
                         if (!string.IsNullOrEmpty(giveKeyModel.FirstName) && !string.IsNullOrEmpty(giveKeyModel.LastName) && giveKeyModel.KeyNumber != 0)
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
