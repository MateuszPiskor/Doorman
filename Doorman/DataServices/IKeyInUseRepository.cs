using Doorman.Model;
using Doorman.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public interface IKeyInUseRepository : IGenericRepository<KeyInUse>
    {
        int GetKeyinUseId(int keyId, int employeeId);
        KeyInUse GetByKeyId(int keyId);
    }
}
