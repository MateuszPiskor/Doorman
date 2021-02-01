using Doorman.Model;

namespace Doorman.Wrappers
{
    public class KeyWrapper : NotficationErrorBaseClass
    {
        private string roomName;
        private int roomNumber;
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
        public int RoomNumber
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
                    if (RoomNumber <= 0 || RoomNumber > 9999)
                    {
                        AddError(propertyName, "Numer pokoju musi się zawierać w przedziale od 1 do 9999");
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
