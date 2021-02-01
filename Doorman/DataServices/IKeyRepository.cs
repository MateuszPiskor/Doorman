using Doorman.Model;

namespace Doorman.DataServices
{
    public interface IKeyRepository : IGenericRepository<Key>
    {
        Key GetIdByRoomNumber(string roomNumber);
    }
}