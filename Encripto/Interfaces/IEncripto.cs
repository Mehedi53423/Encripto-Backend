using Encripto.Response;
using Encripto.ViewModels;

namespace Encripto.Interfaces
{
    public interface IEncripto
    {
        Task<Response<EncriptoVm>> Encode(string inputString);
        Task<Response<EncriptoVm>> Decode(string inputString);
    }
}
