using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Helpers
{
    public class Crypto
    {
        const string stringCrypto = @"@/as1514&%$#\s";
        
        /// <summary>
        /// Permite encriptar un valor
        /// </summary>
        public static string EncriptarDato(string valor)
        {
            byte[] results;
            var utf8 = new System.Text.UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(stringCrypto));
            var tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var dataToEncrypt = utf8.GetBytes(valor);
            try
            {
                var encryptor = tdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }
        /// <summary>
        /// Permite desencriptar un valor
        /// </summary>
        public static string DesencriptarDato(string valor)
        {
            byte[] results = { };
            var utf8 = new System.Text.UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(stringCrypto));
            var tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var dataToDecrypt = Convert.FromBase64String(valor);
            try
            {
                var decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return utf8.GetString(results);
        }
        /// <summary>
        /// Permite transformar un valor
        /// </summary>
        public static string GetMd5(string pass)
        {
            var md5 = MD5.Create();

            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));

            StringBuilder sb = new StringBuilder();

            foreach (byte t in dataMd5)
                sb.AppendFormat("{0:x2}", t);

            return sb.ToString();
        }


    }
}
