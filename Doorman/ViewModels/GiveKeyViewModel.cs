using Doorman.DataServices;
using Doorman.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class GiveKeyViewModel:ViewModelBase, IGiveKeyViewModel
    {
        #region private members
        private string firstName;
        private string lastName;
        private int keyNumber;
        private bool isJustOneEmployee;
        private string idVisibityState = "Hidden";
        private IKeyRepository _keyDataService;
        private IEmployeeRepository _employeeRepository;
        private IKeyInUseRepository _keyInUseReposiotory;
        private ICommand giveKey;
        KeyInUse keyInUse = new KeyInUse();
        private NumberOfEmployessWithTheSameNameSurname CheckNumberOfEmployees()
        {
            var employees = _employeeRepository.GetAll();
            IEnumerable<Employee> matchingEmployess = _employeeRepository.FindEmployeesWithTheSameNameAndSurname(employees, FirstName, LastName);
            if (matchingEmployess.Count() == 0)
            {
                return NumberOfEmployessWithTheSameNameSurname.Zero;
            }
            else if (matchingEmployess.Count() == 1)
            {
                return NumberOfEmployessWithTheSameNameSurname.One;
            }
            return NumberOfEmployessWithTheSameNameSurname.MoreThanOne;
        }
        private bool IsDataCorrect()
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && keyNumber != 0)
            {
                return true;
            }

            return false;
        }
        NumberOfEmployessWithTheSameNameSurname numberOfEmployees;
        enum NumberOfEmployessWithTheSameNameSurname
        {
            Zero, One, MoreThanOne
        }
        #endregion
        #region public properties
        public string IdVisibityState
        {
            get { return idVisibityState; }
            set 
            { 
                idVisibityState = value;
                OnPropertyChange();
            }
        }
        public bool IsJustOneEmployee
        {
            get { return isJustOneEmployee; }
            set 
            { 
                isJustOneEmployee = value;
                OnPropertyChange();
            }
        }
            
        public bool EmployeeIsNotInDB { get; set; }
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
        public bool IsMoreThanOneEmployeeWithSameNameAndSurname { get; set; }
        public ICommand GiveKey
        {
            get {
                if (giveKey == null) giveKey = new RelayCommand(
                     (object o) =>
                     {
                         var numberOfEmployee = CheckNumberOfEmployees();
                         switch (numberOfEmployee)
                         {
                             case NumberOfEmployessWithTheSameNameSurname.One:
                                 {
                                     keyInUse.KeyId = keyNumber;
                                     int EmployeeId = _employeeRepository.GetUserId(FirstName, LastName);
                                     keyInUse.EmployeeId = EmployeeId;
                                     _keyInUseReposiotory.Add(keyInUse);
                                     _keyInUseReposiotory.SaveAsync();
                                     base.OnPropertyChange();

                                     OnPropertyChange();
                                     break;
                                 }
                             case NumberOfEmployessWithTheSameNameSurname.Zero:
                                 {
                                     EmployeeIsNotInDB = true;
                                     OnPropertyChange();
                                     break;
                                 }
                             case NumberOfEmployessWithTheSameNameSurname.MoreThanOne:
                                 {
                                     IsMoreThanOneEmployeeWithSameNameAndSurname = true;
                                     OnPropertyChange();
                                     MessageBox.Show("Jest co najmniej 2 pracowników o tym imieniu i nazwisku, muszisz wprowadzić ID pracownika","Uwaga");
                                     IdVisibityState = "Visible";
                                     break;
                                 }
                         }
                         
                         
                     },
                     (object o) =>
                     {
                         return IsDataCorrect();
                     });
                return giveKey;
            }
           
        }
#endregion
        #region constructors
        public GiveKeyViewModel(IKeyRepository keyDataSerive, IEmployeeRepository employeeRepository, IKeyInUseRepository keyInUseReposiotory)
        {
            _keyDataService = keyDataSerive;
            _employeeRepository = employeeRepository;
            _keyInUseReposiotory = keyInUseReposiotory;
        }
        #endregion
        #region privatemethods
        #endregion
    }
}
