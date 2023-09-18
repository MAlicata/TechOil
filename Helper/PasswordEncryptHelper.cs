using System.Security.Cryptography; //para encriptar la password
using System.Text;

namespace TechOil.Helper
{
    public static class PasswordEncryptHelper
    {
        public static string EncryptPassword(string password)
        {
            var sha256 = SHA256.Create(); //creamos un algoritmo
            var encoding = new ASCIIEncoding(); //instaciamos ASCII
            var stream = Array.Empty<byte>();
            var sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for(int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
    }
}
