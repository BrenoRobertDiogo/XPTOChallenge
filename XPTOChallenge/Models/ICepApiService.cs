using Refit;
using System.Threading.Tasks;

namespace XPTOChallenge.Models
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
