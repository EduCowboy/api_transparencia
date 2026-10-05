using ApiTransparencia.Domain.Models.Deputados;

namespace ApiTransparencia.Domain.Interfaces;

public interface IDeputadosService
{
    Task<DeputadosResponseModel> ObterListaDeputadosAsync(ListaDeputadosRequestModel request);
    Task<DetalhesDeputadosResponseModel> ObterDetalhesDeputadoAsync(DetalhesDeputadosRequestModel request);
    Task<DeputadosDespesasResponseModel> ObterDespesasDeputadoAsync(DeputadosDespesasRequestModel request);
}
