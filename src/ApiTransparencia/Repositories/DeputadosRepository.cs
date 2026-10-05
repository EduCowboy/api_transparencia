using System.Text.Json;
using ApiTransparencia.Domain.Interfaces;
using ApiTransparencia.Domain.Models.Deputados;
using Microsoft.AspNetCore.WebUtilities;

namespace ApiTransparencia.Repositories;

public class DeputadosRepository : IDeputadosRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public DeputadosRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<DeputadosResponseModel> ObterListaDeputadosAsync(ListaDeputadosRequestModel request)
    {
        var baseUrl = _configuration["Endpoints:CamaraApiBaseUrl"];
        
        var endpoint = $"{baseUrl}/deputados";

        var queryParams = new Dictionary<string, string>();

        if (!string.IsNullOrEmpty(request.Nome))
            queryParams.Add("nome", request.Nome);

        if (request.SiglaPartido != null && request.SiglaPartido.Any())
        {
            var partidosStr = string.Join(",", request.SiglaPartido);
            queryParams.Add("siglaPartido", partidosStr);
        }

        if (!string.IsNullOrEmpty(request.Ordem))
            queryParams.Add("ordem", request.Ordem);

        if (!string.IsNullOrEmpty(request.OrdenarPor))
            queryParams.Add("ordenarPor", request.OrdenarPor);

        var urlComQuery = QueryHelpers.AddQueryString(endpoint, queryParams!);

        var response = await _httpClient.GetAsync(urlComQuery);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Erro ao consumir a API da Câmara: {response.ReasonPhrase}");
        }

        var jsonContent = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<DeputadosResponseModel>(jsonContent, options);

        return result!;
    }

    public async Task<DetalhesDeputadosResponseModel> ObterDetalhesDeputadoAsync(DetalhesDeputadosRequestModel request)
    {
        var baseUrl = _configuration["Endpoints:CamaraApiBaseUrl"];
        
        var endpoint = $"{baseUrl}/deputados/{request.Id}";

        var response = await _httpClient.GetAsync(endpoint);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Erro ao consumir a API da Câmara: {response.ReasonPhrase}");
        }

        var jsonContent = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

         var result = JsonSerializer.Deserialize<DetalhesDeputadosResponseModel>(jsonContent, options);

         return result!;
    }
}
