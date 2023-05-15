using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Data.Helpers
{
    public class PasswordGenerator
    {
        public static string GeneratorRandomPassowrd()
        {
            const string charsLower = "abcdefghijklmnopqrstuvwxyz";

            const string charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "0123456789";
            const string caracter = "@#$%";

            int length = 10; 

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int indexCharLower = rnd.Next(charsLower.Length);
                int indexCharUpper = rnd.Next(charsUpper.Length);
                int indexNumber = rnd.Next(number.Length);
                int indexCaracter = rnd.Next(caracter.Length);

                sb.Append(charsLower[indexCharLower]);
                sb.Append(charsUpper[indexCharUpper]);
                sb.Append(number[indexNumber]);
                sb.Append(caracter[indexCaracter]);
            }

            return sb.ToString();
        }
    }
}
