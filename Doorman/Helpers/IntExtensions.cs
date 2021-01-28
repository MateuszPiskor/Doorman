using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Helpers
{
    public static class IntExtensions
    {
        public static string ChangeIdToIdWithInitialZeros(this int number)
        {
            string IdWithInitialZeros = "";

            string numerAsAString= number.ToString();

            IdWithInitialZeros += numerAsAString;

            while (IdWithInitialZeros.Length < 4)
            {
                IdWithInitialZeros = IdWithInitialZeros.Insert(0, "0");
            }
            return IdWithInitialZeros;
        }


    }
}
