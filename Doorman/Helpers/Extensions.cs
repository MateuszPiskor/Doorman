namespace Doorman.Helpers
{
    public static class Extensions
    {
        public static string InitialNextIdWithZeros(this int number)
        {
            string IdWithInitialZeros = "";
            number += 1;

            string numerAsAString = number.ToString();

            IdWithInitialZeros += numerAsAString;

            while (IdWithInitialZeros.Length < 4)
            {
                IdWithInitialZeros = IdWithInitialZeros.Insert(0, "0");
            }
            return IdWithInitialZeros;
        }

    }
}
