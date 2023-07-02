using System.Security.Cryptography;
using System.Text;

namespace Encripto
{
    public class EncoderAndDecoder
    {
        public static readonly string hash = "m€H€d!";

        #region Encode
        public static string Encode(string InputString)
        {
            byte[] data = Encoding.UTF8.GetBytes(InputString);
            byte[] keys = MD5.HashData(Encoding.UTF8.GetBytes(hash));
            using TripleDESCryptoServiceProvider tripDes = new()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = tripDes.CreateEncryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            string output = Convert.ToBase64String(results, 0, results.Length);
            return output;
        }
        #endregion

        #region Decode
        public static string Decode(string InputString)
        {
            byte[] data = Convert.FromBase64String(InputString);
            byte[] keys = MD5.HashData(Encoding.UTF8.GetBytes(hash));
            using TripleDESCryptoServiceProvider tripDes = new()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = tripDes.CreateDecryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            string output = Encoding.UTF8.GetString(results);
            return output;
        }
        #endregion
    }
}
