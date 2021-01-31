using Doorman.Model;
using DoorMan.DataAccess;
using System.Linq;

namespace Doorman.DataServices
{
    public class KeyInUseRepository : GenericRepository<KeyInUse, DoormanDBContext>, IKeyInUseRepository
    {
        private DoormanDBContext _doormanDBContext;

        public KeyInUseRepository(DoormanDBContext doormanDBContext) : base(doormanDBContext)
        {
            _doormanDBContext = doormanDBContext;
        }

        public int GetKeyinUseId(int keyId, int employeeId)
        {
            return _doormanDBContext.KeysInUse.Single(k => k.EmployeeId == employeeId && k.KeyId == keyId).Id;
        }

        public KeyInUse GetByKeyId(int keyId)
        {
            return _doormanDBContext.KeysInUse.SingleOrDefault(k=>k.KeyId == keyId);
        }

    }
}
