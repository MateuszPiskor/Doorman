using Doorman.DataServices;
using Doorman.Model;
using Doorman.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Doorman.ViewModels
{
    public class GiveKeyViewModel : NotficationErrorBaseClass, IGiveKeyViewModel
    {
        #region constructors
        public GiveKeyViewModel(IEmployeeRepository employeeRepository, IKeyInUseRepository keyInUseReposiotory, IKeyRepository keyRepository)
        {
            _employeeRepository = employeeRepository;
            _keyInUseReposiotory = keyInUseReposiotory;
            _keyRepository = keyRepository;
            giveKeyModelWrapper = new GiveKeyModelWrapper(new GiveKeyModel());
            messageBoxList = new List<string>();
        }
        #endregion
        #region private members

        private string messageBoxText;
        private IEmployeeRepository _employeeRepository;
        private IKeyInUseRepository _keyInUseReposiotory;
        private IKeyRepository _keyRepository;
        private GiveKeyModelWrapper giveKeyModelWrapper;
        private List<string> messageBoxList;
        #endregion
        #region public properties
        public GiveKeyModelWrapper GiveKeyModel
        {
            get { return giveKeyModelWrapper; }
            set
            {
                giveKeyModelWrapper = value;
                OnPropertyChange();
            }
        }
        #endregion
        #region commands
        private ICommand giveKey;

        public ICommand GiveKey
        {
            get
            {
                if (giveKey == null)
                {
                    giveKey = new RelayCommand(
                     (object o) =>
                     {
                         messageBoxList.Clear();
                         bool keyExist = true; ;
                         Model.Key Key = _keyRepository.GetIdByRoomNumber(GiveKeyModel.RoomNumber);
                         if (Key == null)
                         {
                             keyExist = false;
                             KeyNoExistAction();
                         }

                         bool KeyIsNotInUse = false;

                         if (keyExist)
                         {
                             KeyIsNotInUse = _keyInUseReposiotory.GetByKeyId(Key.Id) == null;
                             if (!KeyIsNotInUse)
                             {
                                 KeyIsNotInUseAction();
                             }
                         }

                         UniqueEmployees employees = GetUniqueEmployess();
                         bool EmployeeMatch = IsEmployeMatch(employees);
                         if (keyExist && KeyIsNotInUse && EmployeeMatch)
                         {
                             AddKeyInUse(Key);
                             messageBoxList.Add("Klucz został pomyślnie dodany do bazy danych");
                             ShowAllMessage(messageBoxList);
                             ClearForm();
                         }
                         else
                         {
                             ShowAllMessage(messageBoxList);
                         }
                     },
                     (object o) =>
                     {
                         return AreAllPropertiesFielled() && GiveKeyModel != null && !GiveKeyModel.HasErrors;
                     });
                }
                return giveKey;
            }
        }

        private void KeyIsNotInUseAction()
        {
            messageBoxList.Add("Klucz o podanym id został już wydany. Sprawdz spis wydanych kluczy lub popraw dane\n");
            GiveKeyModel.RoomNumber = "";
        }

        private void KeyNoExistAction()
        {
            messageBoxList.Add("Klucz nie istnieje w bazie danych. Popraw jego numer lub wprowadz go do bazy.");
            GiveKeyModel.RoomNumber = "";
        }

        private void ShowAllMessage(List<string> messageBoxList)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < messageBoxList.Count; i++)
            {
                sb.Append($"{i + 1}. {messageBoxList[i]}\n");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Informacja");
            }
        }

        #endregion
        #region private methods
        private void AddKeyInUse(Model.Key key)
        {
            GiveKeyModel.ShowEmployeeId = "Collapsed";
            int EmployeeId = _employeeRepository.GetUserId(GiveKeyModel.FirstName, GiveKeyModel.LastName);
            _keyInUseReposiotory.Add(new KeyInUse() { EmployeeId = EmployeeId, KeyId = key.Id });
            _keyInUseReposiotory.SaveAsync();
            OnPropertyChange();
        }

        private bool IsEmployeMatch(UniqueEmployees employees)
        {
            switch (employees)
            {
                case (UniqueEmployees.Zero):
                    {
                        messageBoxList.Add("W bazie nie istnieje pracownik o tym imieniu i nazwisku. Popraw to.\n");
                        ClearForm();
                        return false;
                    }
                case (UniqueEmployees.One):
                    return true;
                case (UniqueEmployees.MoreThanOne):
                    {
                        if (GiveKeyModel.ShowEmployeeId == "Collapsed")
                        {
                            messageBoxList.Add("W bazie istnieje co najmniej dwoch pracownikow o tym imieniu i nazwisku --> Wprowadz id pracownika\n");
                            GiveKeyModel.ShowEmployeeId = "Visible";
                            GiveKeyModel.IsReadOnly = true;
                            return false;
                        }
                        else if (GiveKeyModel.ShowEmployeeId == "Visible")
                        {
                            if (_employeeRepository.GetAll().SingleOrDefault(e => e.FirstName == GiveKeyModel.FirstName &&
                             e.LastName == GiveKeyModel.LastName && e.Id == GiveKeyModel.EmployeeId) != null)
                            {
                                GiveKeyModel.IsReadOnly = false;
                                return true;
                            }
                            else
                            {
                                messageBoxList.Add($"To id nie należy do użytkownika {GiveKeyModel.FirstName} {GiveKeyModel.LastName} -- >Popraw dane\n");
                                return false;
                            }
                        }
                    }
                    break;
            }
            return true;
        }

        private void ClearForm()
        {
            GiveKeyModel.FirstName = "";
            GiveKeyModel.LastName = "";
            GiveKeyModel.RoomNumber = "";
        }

        private UniqueEmployees GetUniqueEmployess()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAll().Where(e => e.FirstName == GiveKeyModel.FirstName && e.LastName == GiveKeyModel.LastName);
            if (!employees.Any())
            {
                return UniqueEmployees.Zero;
            }
            else if (employees.Count() == 1)
            {
                return UniqueEmployees.One;
            }
            return UniqueEmployees.MoreThanOne;
        }

        private bool AreAllPropertiesFielled()
        {
            if ((GiveKeyModel.FirstName == null || GiveKeyModel.LastName == null || GiveKeyModel.RoomNumber == ""))
            {
                return false;
            }
            return true;
        }
        #endregion
        #region enums
        enum UniqueEmployees
        {
            Zero, One, MoreThanOne
        }
        #endregion
    }
}
