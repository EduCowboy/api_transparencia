using System;

namespace ApiTransparencia.Domain.Models.Deputados;

public class DetalhesDeputadosResponseModel
{
    public DeputadoDetalhesModel? Dados { get; set; }
    public List<LinksModel> Links { get; set; } = new();
}
