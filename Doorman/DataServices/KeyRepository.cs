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

        public Key GetKeyByRoomNumber(string roomNumber)
        {
            return doormanDBContext.Keys.SingleOrDefault(k => k.RoomNumber == roomNumber);
        }

        public string GetRoomNameByRoomNumber(string roomNumber)
        {
            return doormanDBContext.Keys.SingleOrDefault(k => k.RoomNumber == roomNumber).RoomName;
        }
    }
}
