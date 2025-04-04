using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace GGPWD_API
{
    public class PasswordHasher
    {
        private readonly IPasswordHasher<string> _passwordHasher;

        public PasswordHasher(IPasswordHasher<string> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string Encrypt(string plainTextPsw)
        {
            return _passwordHasher.HashPassword(null, plainTextPsw);
        }

        #region "Utility functions"
        /// <summary>
        /// Convert a value from UTF8 to Base64
        /// </summary>
        /// <param name="value">Clear value to convert</param>
        /// <returns>Value in base64</returns>
        public static string EncodeToBase64(string value)
        {
            byte[] clearValue = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(clearValue);
        }

        /// <summary>
        /// Convert a value from Base64 to a UTF8 string
        /// </summary>
        /// <param name="value">Value in base 64 to convert</param>
        /// <returns>Clear value in UTF8</returns>
        public static string DecodeFromBase64ToUTF8(string value)
        {
            byte[] decodedValue = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(decodedValue);
        }

        /// <summary>
        /// Convert a value from Base64 to byte array
        /// </summary>
        /// <param name="value">Base64 string</param>
        /// <returns></returns>
        public static byte[] DecodeFromBase64(string value)
        {
            return Convert.FromBase64String(value);
        }
        #endregion
    }
}
