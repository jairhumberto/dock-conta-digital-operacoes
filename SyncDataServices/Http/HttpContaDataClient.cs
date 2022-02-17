using System.Text;
using System.Text.Json;
using OperacoesService.Dtos;

namespace OperacoesService.SyncDataServices.Http
{
    public class HttpContaDataClient : IContaDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpContaDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendOperacaoToConta(OperacaoReadDto operacao)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(operacao),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_configuration["ContasService"]}", httpContent);

            if(!response.IsSuccessStatusCode)
            {
                throw new HttpSyncException();
            }
        }
    }
}