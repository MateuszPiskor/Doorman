using Doorman.Model;

namespace Doorman.DataServices
{
    public interface IKeyDataService
    {
        void AddKey(Key key);
        void AddGiveKey(KeyInUse giveKeyModel);
    }
}