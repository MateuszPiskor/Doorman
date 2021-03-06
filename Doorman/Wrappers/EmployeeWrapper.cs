﻿using Doorman.Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace Doorman.Wrappers
{
    public class EmployeeWrapper : NotficationErrorBaseClass /*ModelWrapper<Employee>*/
    {
        public EmployeeWrapper(Employee model)
        {
            Model=model;
        }
        public Employee Model { get; set; }
        private string idAsAString;

        public string IdAsAString
        {
            get { return idAsAString; }
            set
            {
                idAsAString = value;
                OnPropertyChange();
                ValidateProperty(nameof(IdAsAString));
            }
        }
        public string FirstName
        {
            get { return Model.FirstName; }
            set
            {
                Model.FirstName = value;
                OnPropertyChange();
                ValidateProperty(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return Model.LastName; }
            set
            {
                Model.LastName = value;
                OnPropertyChange();
                ValidateProperty(nameof(LastName));
            }
        }

        public string Department
        {
            get { return Model.Department; }
            set
            {
                Model.Department = value;
                OnPropertyChange();
                ValidateProperty(nameof(Department));
            }
        }

        public string Position
        {
            get { return Model.Positon; }
            set
            {
                Model.Positon = value;
                OnPropertyChange();
                ValidateProperty(nameof(Position));
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
                    else if(!FirstName.All(char.IsLetter))
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
                        else if (!Regex.IsMatch(LastName, @"^[a-zA-Z\-`śćźżąęół]*$"))
                        {
                            AddError(propertyName, "Nie poprawany format nazwiska");
                        }
                        break;
                    }
                case nameof(Department):
                    {
                        if (Department.Length < 2)
                        {
                            AddError(propertyName, "Nazwa odziału musi zawierać co najmniej 2 znaki.");
                        }
                        break;
                    }
                case nameof(Position):
                    {
                        if (Position.Length < 2)
                        {
                            AddError(propertyName, "Nazwa pozycji musi zawierać co najmniej 2 znaki.");
                        }
                        break;
                    }
                case nameof(IdAsAString):
                    if (!Regex.IsMatch(idAsAString, @"^[0-9]{4}$"))
                    {
                        AddError(propertyName, "Id pracownika musi się składać z 4 cyfr");
                    }
                    break;
            }
        }
    }
}
