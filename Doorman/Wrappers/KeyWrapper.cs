using Doorman.Model;
using System.Text.RegularExpressions;

namespace Doorman.Wrappers
{
    public class KeyWrapper : NotficationErrorBaseClass
    {
        private string roomName;
        private string roomNumber;
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChange();
            }
        }


        public Key Model { get; set; }

        public KeyWrapper(Key model)
        {
            Model = model;
        }

        public string RoomName
        {
            get
            {
                return roomName;
            }
            set
            {
                roomName = value;
                OnPropertyChange();
                ValidateProperty(nameof(RoomName));
            }
        }
        public string RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                roomNumber = value;
                OnPropertyChange();
                ValidateProperty(nameof(RoomNumber));
            }
        }

        

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(RoomNumber):
                    if (!Regex.IsMatch(roomNumber, @"^[0-9]{4}$"))
                    {
                        AddError(propertyName, "Numer pokoju musi składa się z 4 cyfr");
                    }
                    break;
                case nameof(RoomName):
                    if (RoomName.Length < 2)
                    {
                        AddError(propertyName, "Za krótka nazwa pomieszczenia");
                    }
                    else if (RoomName.Length > 50)
                    {
                        AddError(propertyName, "Za krótka nazwa pomieszczenia");
                    }
                    break;
            }
        }

    }
}
