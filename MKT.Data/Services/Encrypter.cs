using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Data.Services
{
    public class Encrypter
    {
        public static string Encriptar(string Pass)
        {
            //Para encriptar uso SHA256

            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] stream = null;
            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(Pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static bool Validar(string Pass, string PassHashData)
        {
            string Passhash;
            Passhash = Encrypter.Encriptar(Pass);

            if (Passhash == PassHashData)

            {
                return true;
            }

            else

            {
                return false;
            }

        }
        public static string GeneradorClave()
        {
            string clave = Guid.NewGuid().ToString();

            return clave;

        }
    }
}
