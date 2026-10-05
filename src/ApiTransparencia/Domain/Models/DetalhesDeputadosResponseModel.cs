using System;

namespace ApiTransparencia.Domain.Models;

public class DetalhesDeputadosResponseModel
{
    public DeputadoDetalhesModel? Dados { get; set; }
    public List<LinksModel> Links { get; set; } = new();
}
