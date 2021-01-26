using Doorman.Model;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public class KeyDataService: IKeyDataService
    {
        DoormanDBContext doormanDBContext;

        public KeyDataService(DoormanDBContext doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }

        public void AddGiveKey(KeyInUse giveKeyModel)
        {
            throw new NotImplementedException();
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
