using Encripto.Interfaces;
using Encripto.Response;
using Encripto.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace Encripto.Implementations
{
    public class EncriptoService : IEncripto
    {
        public static readonly string hash = "m€H€d!";

        #region Encode
        public async Task<Response<EncriptoVm>> Encode(string inputString)
        {
            byte[] data = Encoding.UTF8.GetBytes(inputString);
            byte[] keys = MD5.HashData(Encoding.UTF8.GetBytes(hash));
            using TripleDESCryptoServiceProvider tripDes = new()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = tripDes.CreateEncryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);

            var response = new EncriptoVm
            {
                OutputString = Convert.ToBase64String(results, 0, results.Length)
            };

            return Response<EncriptoVm>.Success(response, "Successfully Encoded");
        }
        #endregion

        #region Decode
        public async Task<Response<EncriptoVm>> Decode(string inputString)
        {
            byte[] data = Convert.FromBase64String(inputString);
            byte[] keys = MD5.HashData(Encoding.UTF8.GetBytes(hash));
            using TripleDESCryptoServiceProvider tripDes = new()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = tripDes.CreateDecryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);

            var response = new EncriptoVm
            {
                OutputString = Encoding.UTF8.GetString(results)
            };

            return Response<EncriptoVm>.Success(response, "Successfully Decoded");
        }
        #endregion
    }
}
