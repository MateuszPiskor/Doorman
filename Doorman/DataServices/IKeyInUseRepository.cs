using Doorman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public interface IKeyInUseRepository : IGenericRepository<KeyInUse>
    {
        int GetKeyinUseId(int keyId, int employeeId);
    }
}
