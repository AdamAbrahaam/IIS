using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Services
{
    public class PasswordHasher
    {
        private string _password { get; set; }

        public PasswordHasher(string password)
        {
            this._password = password;
        }

        public string GetHashedPassword()
        {
            return HashPassword(this._password);
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] arrayOfSha256 = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder returnString = new StringBuilder();

                foreach (var b in arrayOfSha256)
                    returnString.Append(b.ToString("x2"));

                return returnString.ToString();
            }
        }
    }
}
