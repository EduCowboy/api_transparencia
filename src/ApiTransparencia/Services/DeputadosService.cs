using ApiTransparencia.Domain.Interfaces;
using ApiTransparencia.Domain.Models.Deputados;

namespace ApiTransparencia.Services;

public class DeputadosService : IDeputadosService
{
    private readonly IDeputadosRepository _deputadosRepository;

    public DeputadosService(IDeputadosRepository deputadosRepository)
    {
        _deputadosRepository = deputadosRepository;
    }

    public async Task<DeputadosResponseModel> ObterListaDeputadosAsync(ListaDeputadosRequestModel request)
    {
        var response = await _deputadosRepository.ObterListaDeputadosAsync(request);
        return response;
    }

    public async Task<DetalhesDeputadosResponseModel> ObterDetalhesDeputadoAsync(DetalhesDeputadosRequestModel request)
    {
        var response = await _deputadosRepository.ObterDetalhesDeputadoAsync(request);
        return response;
    }

    public async Task<DeputadosDespesasResponseModel> ObterDespesasDeputadoAsync(DeputadosDespesasRequestModel request)
    {
        var response = await _deputadosRepository.ObterDespesasDeputadoAsync(request);
        return response;
    }
}
