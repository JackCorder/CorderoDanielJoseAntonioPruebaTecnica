﻿using System.Security.Cryptography;
using System.Text;

namespace CorderoDanielJoseAntonioPruebaTecnica.Settings
{
    public static class AesEncryptionHelper
    {
        private static readonly string Key = "12345678901234567890123456789012";
        private static readonly string IV = "1234567890123456"; 

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs)) sw.Write(plainText);
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string encrypted)
        {
            var buffer = Convert.FromBase64String(encrypted);
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(buffer);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
