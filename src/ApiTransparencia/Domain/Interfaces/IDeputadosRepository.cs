using System;
using ApiTransparencia.Domain.Models;

namespace ApiTransparencia.Domain.Interfaces;

public interface IDeputadosRepository
{
    Task<DeputadosResponseModel> ObterListaDeputadosAsync(ListaDeputadosRequestModel request);
    Task<DetalhesDeputadosResponseModel> ObterDetalhesDeputadoAsync(DetalhesDeputadosRequestModel request);
}
