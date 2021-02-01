using Doorman.Model;

namespace Doorman.Wrappers
{
    public class KeyEditModelWrapper : NotficationErrorBaseClass
    {
        private int roomNumber;
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                ValidateProperty(nameof(Id));
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
            }
        }

    }
}
