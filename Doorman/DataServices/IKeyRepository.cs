using Doorman.Model;

namespace Doorman.DataServices
{
    public interface IKeyRepository : IGenericRepository<Key>
    {
        Key GetKeyByRoomNumber(string roomNumber);
        string GetRoomNameByRoomNumber(string roomNumber);
    }
}