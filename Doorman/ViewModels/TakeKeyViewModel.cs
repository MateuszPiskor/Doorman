using Doorman.DataServices;
using Doorman.Model;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class TakeKeyViewModel : ViewModelBase, ITakeKeyViewModel
    {
        #region private members
        private IEmployeeRepository _employeeDataService;
        private string firstName;
        KeyInUse keyInUse = new KeyInUse();
        private IKeyRepository _keyDataService;
        private IKeyInUseRepository _keyInUseReposiotory;
        private int keyNumber;
        private string lastName;
        private ICommand takeKey;
        #endregion
        #region properties
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChange();
            }
        }
        public int KeyNumber
        {
            get { return keyNumber; }
            set
            {
                keyNumber = value;

            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;

            }
        }
        public ICommand TakeKey
        {
            get
            {
                if (takeKey == null)
                {
                    takeKey = new RelayCommand(
                     (object o) =>
                     {
                         //keyInUse.KeyId = keyNumber;
                         int employeeId = _employeeDataService.GetUserId(FirstName, LastName);
                         //keyInUse.EmployeeId = EmployeeId;
                         keyInUse.Id = _keyInUseReposiotory.GetKeyinUseId(keyNumber, employeeId);
                         var keytoRemove = _keyInUseReposiotory.GetById(keyInUse.Id);

                         _keyInUseReposiotory.Remove(keytoRemove);
                         _keyInUseReposiotory.SaveAsync();
                         base.OnPropertyChange();

                     },
                     (object o) =>
                     {
                         return IsDataCorrect();
                         //if (key.RoomNumber != 0 && key.RoomName != "")
                         //{
                         //    return true;
                         //}
                         //return false;
                     });
                }

                return takeKey;
            }

        }
        #endregion
        #region costructors
        public TakeKeyViewModel(IKeyRepository keyDataSerive, IEmployeeRepository employeeDataService, IKeyInUseRepository keyInUseReposiotory)
        {
            _keyDataService = keyDataSerive;
            _employeeDataService = employeeDataService;
            _keyInUseReposiotory = keyInUseReposiotory;
        }
        #endregion
        #region privatemethods
        private bool IsDataCorrect()
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && keyNumber != 0)
            {
                return true;
            }

            return false;
        }
        #endregion
    }

}
