using Doorman.Model;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public class KeyRepository: GenericRepository<Key, DoormanDBContext>,
                                   IKeyRepository
    {
        DoormanDBContext doormanDBContext;

        public KeyRepository(DoormanDBContext doormanDBContext):base(doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }


        public void AddKey(Key key)
        {
            var keys = doormanDBContext.Set<Key>();
            var keyEntity = new Key() { RoomName = key.RoomName, RoomNumber = key.RoomNumber }; 
            keys.Add(keyEntity);
            doormanDBContext.SaveChanges();
        }
    }
}
