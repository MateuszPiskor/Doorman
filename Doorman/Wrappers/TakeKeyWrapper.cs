using Doorman.Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace Doorman.Wrappers
{
    public class TakeKeyWrapper : NotficationErrorBaseClass
    {
        public TakeKeyWrapper(TakeKeyModel model)
        {
            Model = model;
        }
        private int id;
        private string firstName;
        private string lastName;
        private string keyNumber;
        
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange();
                ValidateProperty(nameof(Id));
            }
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
        public string KeyNumber
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
                    if (!Regex.IsMatch(keyNumber, @"^[0-9]{4}$"))
                    {
                        AddError(propertyName, "Numer pokoju musi składa się z 4 cyfr");
                    }
                    break;
            }
        }
    }
}
