using Doorman.Model;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public class KeyInUseRepository: GenericRepository<KeyInUse, DoormanDBContext>,IKeyInUseRepository
    {
        private DoormanDBContext _doormanDBContext;

        public KeyInUseRepository(DoormanDBContext doormanDBContext):base(doormanDBContext)
        {
            _doormanDBContext = doormanDBContext;
        }

        public int GetKeyinUseId(int keyId, int employeeId)
        {
            return _doormanDBContext.KeysInUse.Single(k => k.EmployeeId ==employeeId && k.KeyId == keyId).Id;
        }

       
    }
}
