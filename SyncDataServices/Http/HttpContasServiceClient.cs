using System.Text;
using System.Text.Json;
using OperacoesService.Dtos;

namespace OperacoesService.SyncDataServices.Http
{
    public class HttpContasServiceClient : IContasServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpContasServiceClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task ProcessaOperacao(OperacaoReadDto operacaoReadDto)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(operacaoReadDto), Encoding.UTF8,
                    "application/json");
            var response = await _httpClient.PostAsync($"{_configuration["ContasService"]}", httpContent);

            if(!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
    }
}