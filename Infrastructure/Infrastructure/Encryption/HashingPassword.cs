using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Encryption
{
    public class HashingPassword
    {
        public string Salt { get; set; }
        public string HashPassword(string password)
        {
            var rng = RandomNumberGenerator.Create();
            var saltbytes = new Byte[16];
            rng.GetBytes(saltbytes);
            var salttext = Convert.ToBase64String(saltbytes);
            Salt = salttext;
            return SaltAndHash(password,salttext);
        }
        private static string SaltAndHash(string password,string salt)
        {
            var sha = SHA256.Create();
            var saltpassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltpassword)));
        }
    }
}
