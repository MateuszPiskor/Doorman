using Doorman.Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace Doorman.Wrappers
{
    public class KeyWrapper : NotficationErrorBaseClass 
    {
        public Key Model { get; set; }
        public KeyWrapper(Key model)
        {
            Model=model;
        }

        public int Id { get { return Model.Id; } }


        public int RoomNumber
        {
            get
            {
                return Model.RoomNumber;
            }
            set
            {
                Model.RoomNumber = value;
                OnPropertyChange();
                ValidateProperty(nameof(RoomNumber));
            }
        }
       

        public string RoomName
        {
            get { return Model.RoomName; }
            set
            {
                Model.RoomName = value;
                OnPropertyChange();
                ValidateProperty(nameof(RoomName));
            }
        }


        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(RoomNumber):
                    if (RoomNumber < 0 || RoomNumber >9999)
                    {
                        AddError(propertyName, "Numer pokoju musi się zawierać w przedziale od 1 do 9999");
                    }
                    break;
                case nameof(RoomName):
                    if (RoomName.Length < 2)
                    {
                        AddError(propertyName, "Za krótka nazwa pokoju");
                    }
                    else if (RoomName.Length > 50)
                    {
                        AddError(propertyName, "Za długa nazwa pokoju");
                    }
                    
                    break;
            }
        }


        //protected override IEnumerable<string> ValidateProperty(string propertyName)
        //{
        //    switch (propertyName)
        //    {
        //        case nameof(FirstName):
        //            if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
        //            {
        //                yield return "Robots are not valid friends";
        //            }
        //            break;
        //    }
        //}
    }
}
