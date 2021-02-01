using Doorman.Model;
using System.Text.RegularExpressions;

namespace Doorman.Wrappers
{
    public class KeyEditModelWrapper : NotficationErrorBaseClass
    {
        private int id;
        private string roomNumber;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                ValidateProperty(nameof(Id));
            }
        }
        public string RoomNumber
        {
            get { return roomNumber; }
            set
            {
                roomNumber = value;
                ValidateProperty(nameof(RoomNumber));
            }
        }
        public KeyEditModel KeyEditModel { get; set; }
        public KeyEditModelWrapper(KeyEditModel model)
        {
            KeyEditModel = model;
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(Id):
                    if (Id <= 0 || Id > 9999)
                    {
                        AddError(propertyName, "Numer pokoju musi się zawierać w przedziale od 1 do 9999");
                    }
                    break;
                case nameof(RoomNumber):
                    if (!Regex.IsMatch(roomNumber, @"^[0-9]{4}$"))
                    {
                        AddError(propertyName, "Numer pokoju musi składa się z 4 cyfr");
                    }
                    break;
            }
        }
    }
}
