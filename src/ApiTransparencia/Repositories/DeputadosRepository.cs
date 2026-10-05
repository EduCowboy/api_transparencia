using System;
using System.Text.Json;
using ApiTransparencia.Domain.Interfaces;
using ApiTransparencia.Domain.Models;
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
        // Lê a URL base direto do appsettings.json
        var baseUrl = _configuration["Endpoints:CamaraApiBaseUrl"];
        
        // Monta o endpoint completo (https://dadosabertos.camara.leg.br/api/v2/deputados)
        var endpoint = $"{baseUrl}/deputados";

        // Dicionário para mapear os parâmetros da request
        var queryParams = new Dictionary<string, string>();

        if (!string.IsNullOrEmpty(request.Nome))
            queryParams.Add("nome", request.Nome);

        if (request.SiglaPartido != null && request.SiglaPartido.Any())
        {
            // Transforma a lista ["PL", "PT"] em uma string "PL,PT"
            var partidosStr = string.Join(",", request.SiglaPartido);
            queryParams.Add("siglaPartido", partidosStr);
        }

        if (!string.IsNullOrEmpty(request.Ordem))
            queryParams.Add("ordem", request.Ordem);

        if (!string.IsNullOrEmpty(request.OrdenarPor))
            queryParams.Add("ordenarPor", request.OrdenarPor);

        // Adiciona os parâmetros à URL tratando acentos e caracteres especiais
        var urlComQuery = QueryHelpers.AddQueryString(endpoint, queryParams);

        // Faz a requisição GET para a API externa
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

        return JsonSerializer.Deserialize<DeputadosResponseModel>(jsonContent, options);
    }

    public async Task<DetalhesDeputadosResponseModel> ObterDetalhesDeputadoAsync(DetalhesDeputadosRequestModel request)
    {
        var baseUrl = _configuration["Endpoints:CamaraApiBaseUrl"];
        
        // Monta o endpoint completo (https://dadosabertos.camara.leg.br/api/v2/deputados)
        var endpoint = $"{baseUrl}/deputados/{request.Id}";

        // Faz a requisição GET para a API externa
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

        return JsonSerializer.Deserialize<DetalhesDeputadosResponseModel>(jsonContent, options);
    }
}
