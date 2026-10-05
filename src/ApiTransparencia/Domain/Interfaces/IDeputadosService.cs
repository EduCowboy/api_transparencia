using ApiTransparencia.Domain.Models;

namespace ApiTransparencia.Domain.Interfaces;

public interface IDeputadosService
{
    Task<DeputadosResponseModel> ObterListaDeputadosAsync(ListaDeputadosRequestModel request);
    Task<DetalhesDeputadosResponseModel> ObterDetalhesDeputadoAsync(DetalhesDeputadosRequestModel request);
}
