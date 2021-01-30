using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class GiveKeyViewModel : NotficationErrorBaseClass, IGiveKeyViewModel
    {
        #region constructors
        public GiveKeyViewModel(IKeyRepository keyDataSerive, IEmployeeRepository employeeRepository, IKeyInUseRepository keyInUseReposiotory)
        {
            _keyDataService = keyDataSerive;
            _employeeRepository = employeeRepository;
            _keyInUseReposiotory = keyInUseReposiotory;
            giveKeyModel = new GiveKeyModelWrapper(new GiveKeyModel());
        }
        #endregion
        #region private members

        private IKeyRepository _keyDataService;
        private IEmployeeRepository _employeeRepository;
        private IKeyInUseRepository _keyInUseReposiotory;
        private GiveKeyModelWrapper giveKeyModel;
        #endregion
        #region public properties
        public GiveKeyModelWrapper GiveKeyModel
        {
            get { return giveKeyModel; }
            set { giveKeyModel = value;
                OnPropertyChange();
            }
        }
        #endregion
        #region comands
        private ICommand giveKey;
        public ICommand GiveKey
        {
            get {
                if (giveKey == null) giveKey = new RelayCommand(
                     (object o) =>
                     {
                         var numberOfEmployee = CheckNumberOfEmployees();
                         bool isKeyExist = _keyDataService.GetById(GiveKeyModel.KeyId) != null;
                         bool isEmployeeExist = _employeeRepository.GetById(GiveKeyModel.EmployeeId) != null;
                         if (numberOfEmployee == NumberOfEmployessWithTheSameNameSurname.MoreThanOne && GiveKeyModel.EmployeeId != 0)
                         {
                             if (!isEmployeeExist)
                             {
                                 MessageBox.Show("User o takim id nie istnieje. Popraw dane", "Uwaga");
                             }
                             GiveKeyModel.ShowEmployeeId = "Collapsed";
                             GiveKeyModel.EmployeeId = 0;
                             AddEmployee();
                         }
                         else if (numberOfEmployee == NumberOfEmployessWithTheSameNameSurname.One)
                         {
                             GiveKeyModel.ShowEmployeeId = "Collapsed";
                             AddEmployee();
                         }
                         else if (numberOfEmployee == NumberOfEmployessWithTheSameNameSurname.Zero)
                         {
                             GiveKeyModel.ShowEmployeeId = "Collapsed";
                             OnPropertyChange();
                         }
                         else if (numberOfEmployee == NumberOfEmployessWithTheSameNameSurname.MoreThanOne)
                         {
                             OnPropertyChange();
                             MessageBox.Show("Jest co najmniej 2 pracowników o tym imieniu i nazwisku, muszisz wprowadzić ID pracownika", "Uwaga");
                             GiveKeyModel.ShowEmployeeId = "Visible";
                             OnPropertyChange();
                         }
                         OnPropertyChange();
                     },
                     (object o) =>
                     {
                         return AreAllPropertiesFielled() && GiveKeyModel != null && !GiveKeyModel.HasErrors;
                     });
                return giveKey;
            }
        }

        private void AddEmployee()
        {
            GiveKeyModel.ShowEmployeeId = "Collapsed";
            int EmployeeId = _employeeRepository.GetUserId(GiveKeyModel.Model.FirstName, GiveKeyModel.Model.LastName);
            _keyInUseReposiotory.Add(new KeyInUse() { EmployeeId = EmployeeId, KeyId = GiveKeyModel.KeyId });
            _keyInUseReposiotory.SaveAsync();
            OnPropertyChange();
        }
        #endregion
        #region private methods
        private NumberOfEmployessWithTheSameNameSurname CheckNumberOfEmployees()
        {
            var employees = _employeeRepository.GetAll();
            IEnumerable<Employee> matchingEmployess = _employeeRepository.FindEmployeesWithTheSameNameAndSurname(employees, GiveKeyModel.FirstName, GiveKeyModel.LastName);
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

        private bool AreAllPropertiesFielled()
        {
            if ((GiveKeyModel.FirstName == null || GiveKeyModel.LastName == null || GiveKeyModel.KeyId == 0))
            {
                return false;
            }
            return true;
        }
        #endregion
        #region enums
        enum NumberOfEmployessWithTheSameNameSurname
        {
            Zero, One, MoreThanOne
        }
        #endregion
    }
}
