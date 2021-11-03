using ConsultandoPrevisao.Interfaces;
using Refit;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace ConsultandoPrevisao
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("https://viacep.com.br/");
                var previsaoTemperatura = RestService.For<IPrevisao>("https://data.metsul.com/");
                
                Write("Informe seu CEP: ");
                string cepInformado = ReadLine().ToString();

                WriteLine("Consultando informações do CEP: {0}\n\nPor favor aguarde...\n\n\n", cepInformado);
                var address = await cepClient.GetAddressAsync(cepInformado);

                WriteLine($"Bairro: {address.Bairro} - Cidade: {address.Localidade} - Estado: {address.Uf}\n");
                string cidade = address.Bairro.ToString()+"-"+address.Uf.ToString();

                var cidPrevisao = await previsaoTemperatura.GetPrevisaoAsync(cidade);
                
                WriteLine("============================ -- | PREVISÃO DO TEMPO - {0} | -- ============================",cidade);
                foreach (var item in cidPrevisao.dados)
                {
                    string dateString = $"{item.dia}/{item.mes}/{item.ano}";
                    var ParseDate = DateTime.Parse(dateString);

                    WriteLine($"\n{ParseDate.ToString("dddd dd/MM/yy")}\n\n" +
                        $"Mínima: {item.minima}°C / Máxima:{item.maxima}°C \n" +
                        $"Vento: {item.vento} Km/h\n" +
                        $"Precipitação: {item.prec}\n\n" +
                        $"======================================================");
                }
            }
            catch (Exception e)
            {
                WriteLine("Erro na consulta de cep: {0}", e.Message);
            }
        }

    }
}
