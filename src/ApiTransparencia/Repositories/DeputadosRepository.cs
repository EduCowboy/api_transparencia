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
        
        var endpoint = $"{baseUrl}deputados";

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
        
        var endpoint = $"{baseUrl}deputados/{request.Id}";

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

    public async Task<DeputadosDespesasResponseModel> ObterDespesasDeputadoAsync(DeputadosDespesasRequestModel request)
    {
        var baseUrl = _configuration["Endpoints:CamaraApiBaseUrl"];
        
        var endpoint = $"{baseUrl}deputados/{request.Id}/despesas";

         var queryParams = new Dictionary<string, string>();

        if (request.IdLegislatura != null && request.IdLegislatura.Any())
        {
            var legislaturasStr = string.Join(",", request.IdLegislatura);
            queryParams.Add("idLegislatura", legislaturasStr);
        }

        if (request.Ano != null && request.Ano.Any())
        {
            var anosStr = string.Join(",", request.Ano);
            queryParams.Add("ano", anosStr);
        }

        if (request.Mes != null && request.Mes.Any())
        {
            var mesesStr = string.Join(",", request.Mes);
            queryParams.Add("mes", mesesStr);
        }

        if (!string.IsNullOrEmpty(request.CnpjCpfFornecedor))
            queryParams.Add("cnpjCpfFornecedor", request.CnpjCpfFornecedor);

        if (!string.IsNullOrEmpty(request.Pagina))
            queryParams.Add("pagina", request.Pagina);

        if (!string.IsNullOrEmpty(request.Itens))
            queryParams.Add("itens", request.Itens);

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

        var result = JsonSerializer.Deserialize<DeputadosDespesasResponseModel>(jsonContent, options);

         return result!;
    }
}
