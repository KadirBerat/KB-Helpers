using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KB.Helpers
{
    public static class HashHelper
    {
        private static UnicodeEncoding ue = new UnicodeEncoding();
        public static string HashMD5(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-","");
            }
            return "";
        }
        public static string Hash_MD5(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string HashSHA1(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha1.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string Hash_SHA1(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha1.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string HashSHA256(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha256.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string Hash_SHA256(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha256.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string HashSHA384(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha384.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string Hash_SHA384(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha384.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string HashSHA512(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha512.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
        public static string Hash_SHA512(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
                byte[] strBytes = ue.GetBytes(str);
                byte[] hashBytes = sha512.ComputeHash(strBytes);
                return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
            return "";
        }
    }
}
