using Doorman.Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace Doorman.Wrappers
{
    public class KeyWrapper : NotficationErrorBaseClass 
    {
        public KeyWrapper(Key model)
        {
            Model=model;
        }
        public Key Model { get; set; }

        public int Id { get { return Model.Id; } }

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
                case nameof(RoomName):
                    if (RoomName.Length < 2)
                    {
                        AddError(propertyName, "Za krótka nazwa pokoju.");
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
