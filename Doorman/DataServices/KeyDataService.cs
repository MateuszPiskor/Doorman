using Doorman.Model;
using DoorMan.DataAccess;
using DoorMan.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public class KeyDataService:IKeyDataService
    {
        DoormanDBContext doormanDBContext;

        public KeyDataService(DoormanDBContext doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }

        public void AddKey(DoorKey key)
        {
            var keys = doormanDBContext.Set<KeyEntity>();
            var keyEntity = new KeyEntity() { RoomName = key.RoomName, RoomNumber = key.RoomNumber }; 
            keys.Add(keyEntity);
            doormanDBContext.SaveChanges();
            
            
        }
    }
}
