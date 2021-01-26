using Doorman.Model;

namespace Doorman.DataServices
{
    public interface IKeyDataService
    {
        void AddKey(DoorKey key);
        void AddGiveKey(GiveKeyModel giveKeyModel);
    }
}