using System;
using System.Security.Cryptography;
using System.Text;

namespace STS.Common.Cryptography.Services
{
    public class EncryptorService : IEncryptorService
    {
        public string EncryptUserData(string login, string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);

            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(login));

                using (var tripDes = new TripleDESCryptoServiceProvider { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);

                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
    }
}