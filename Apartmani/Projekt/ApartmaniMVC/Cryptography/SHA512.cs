using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ApartmaniMVC.Cryptography
{
    public static class SHA512
    {
        public static string HashPassword(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}