using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

namespace WindowsFormsApp1.Classes
{
    internal class PasswordHash
    {
        public static string Create(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashSenha = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashSenha;
        }

        public static bool Verify(string password, string savedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, savedHash);
        }
    }
}
