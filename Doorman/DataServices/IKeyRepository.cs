using Doorman.Model;

namespace Doorman.DataServices
{
    public interface IKeyRepository: IGenericRepository<Key>
    {
        void AddKey(Key key);
    }
}