using ConsultandoPrevisao.Models;
using Refit;
using System.Threading.Tasks;

namespace ConsultandoPrevisao.Interfaces
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json/")]
        Task<CepResponse> GetAddressAsync(string cep);
        
    }
}
