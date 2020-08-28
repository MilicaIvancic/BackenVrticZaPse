using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aplication.helpers
{
    public static class PasswordGenerator
    {
        public static string Make(string unhashedPassword)
        {
            var md5 = MD5.Create();
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(unhashedPassword));
            var hashedPassword = BitConverter.ToString(result).Replace("-", "").ToLower();

            return hashedPassword;
        }
    }

}
