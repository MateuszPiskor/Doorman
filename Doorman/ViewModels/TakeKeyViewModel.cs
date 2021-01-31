using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class TakeKeyViewModel : NotficationErrorBaseClass, ITakeKeyViewModel
    {
        #region private members
        private IEmployeeRepository _employeeDataService;
        private string firstName;
        private IKeyRepository _keyDataService;
        private IKeyInUseRepository _keyInUseReposiotory;
        private int keyNumber;
        private string lastName;
        private ICommand takeKey;
        KeyInUse keyInUse = new KeyInUse();

        #endregion
        #region properties
        public TakeKeyWrapper TakeKeyModelWrapper { get; set; }
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
                         int employeeId = _employeeDataService.GetUserId(TakeKeyModelWrapper.FirstName, TakeKeyModelWrapper.LastName);
                         //keyInUse.EmployeeId = EmployeeId
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
        public TakeKeyViewModel(IKeyRepository keyDataSerive, IEmployeeRepository employeeDataService, IKeyInUseRepository keyInUseReposiotory, TakeKeyWrapper takeKeyWrapper)
        {
            _keyDataService = keyDataSerive;
            _employeeDataService = employeeDataService;
            _keyInUseReposiotory = keyInUseReposiotory;
            TakeKeyModelWrapper = takeKeyWrapper;
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
