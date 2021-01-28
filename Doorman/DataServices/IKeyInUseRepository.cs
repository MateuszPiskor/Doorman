using Doorman.Model;

namespace Doorman.DataServices
{
    public interface IKeyInUseRepository : IGenericRepository<KeyInUse>
    {
        int GetKeyinUseId(int keyId, int employeeId);
    }
}
