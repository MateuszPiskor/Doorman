using Doorman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Wrappers
{
    public class GiveKeyModelWrapper:NotficationErrorBaseClass
    {
        public GiveKeyModel Model;
        public GiveKeyModelWrapper(GiveKeyModel model)
        {
            Model = model;
        }

        private string firstName;
        private string lastName;
        private int employeeId;
        private int keyId;
        private string showEmployeeId = "Collapsed";
        private bool isReadOnly;


        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
                OnPropertyChange();
                ValidateProperty(nameof(FirstName));
            }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value;
                OnPropertyChange();
               ValidateProperty(nameof(LastName));
            }
        }
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value;
                OnPropertyChange();
                ValidateProperty(nameof(EmployeeId));
            }
        }
        public int KeyId
        {
            get { return keyId; }
            set { keyId = value;
                OnPropertyChange();
                ValidateProperty(nameof(KeyId));
            }
        }

        public string ShowEmployeeId
        {
            get { return showEmployeeId; }
            set
            {
                showEmployeeId = value;
                OnPropertyChange();
                ValidateProperty(nameof(ShowEmployeeId));
            }
        }

        public bool IsReadOnly {
            get { return isReadOnly; }
            set
            {
                isReadOnly = value;
                OnPropertyChange();
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (FirstName.Length < 2)
                    {
                        AddError(propertyName, "Za krótkie imie.");
                    }
                    else if (FirstName.Length > 20)
                    {
                        AddError(propertyName, "Imie nie może być dłuższe niż 20 znaków.");
                    }
                    //else if(!Regex.IsMatch(FirstName,"^[a - zA - Z]*$"))
                    else if (!FirstName.All(char.IsLetter))
                    {
                        AddError(propertyName, "Imie nie może zawierać cyfr");
                    }
                    break;
                case nameof(LastName):
                    {
                        if (LastName.Length < 2)
                        {
                            AddError(propertyName, "Nazwisko za krótkie.");
                        }
                        else if (!LastName.All(char.IsLetter))
                        {
                            AddError(propertyName, "Nazwisko nie może zawierać cyfr");
                        }
                        break;
                    }
                case nameof(KeyId):
                    if (KeyId <= 0 || KeyId > 9999)
                    {
                        AddError(propertyName, "Numer klucza musi się zawierać w przedziale od 1 do 9999");
                    }
                    break;
                case nameof(EmployeeId):
                    if (EmployeeId <= 0 || EmployeeId > 9999)
                    {
                        AddError(propertyName, "Numer id musi się zawierać w przedziale od 1 do 9999");
                    }
                    break;
            }
        }


    }
}
