using Doorman.Model;
using Doorman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Wrappers
{
    public class TakeKeyWrapper: NotficationErrorBaseClass
    {
        private string firstName;
        private string lastName;
        private int keyNumber;
        public TakeKeyWrapper(TakeKeyModel model)
        {
            Model = model;
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChange();
                ValidateProperty(nameof(FirstName));
            }
        }
        public int KeyNumber
        {
            get { return keyNumber; }
            set
            {
                keyNumber = value;
                ValidateProperty(nameof(KeyNumber));
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                ValidateProperty(nameof(LastName));
            }
        }

        public TakeKeyModel Model { get; }

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
                case nameof(KeyNumber):
                    if (KeyNumber <= 0 || KeyNumber > 9999)
                    {
                        AddError(propertyName, "Numer klucza musi się zawierać w przedziale od 1 do 9999");
                    }
                    break;
            }
        }
    }
}
