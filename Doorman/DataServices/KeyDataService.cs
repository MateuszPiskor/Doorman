using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public class KeyDataService:IKeyDataService
    {
        private Func<DoormanDBContext> doormanDBContext;

        public KeyDataService(Func<DoormanDBContext> doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }
    }
}
