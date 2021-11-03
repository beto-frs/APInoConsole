using ConsultandoPrevisao.Models;
using Refit;
using System.Threading.Tasks;

namespace ConsultandoPrevisao.Interfaces
{

    public interface IPrevisao
    {
        [Get("/api/v1/previsao/10dias/quadro_novo/{cidade}")]
        public Task<PrevisaoResponse> GetPrevisaoAsync(string cidade);
    }
}
