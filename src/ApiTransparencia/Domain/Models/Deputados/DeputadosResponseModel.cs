using System;

namespace ApiTransparencia.Domain.Models.Deputados;

public class DeputadosResponseModel
{
    public List<DeputadosModel> Dados { get; set; } = new();
    public List<LinksModel> Links { get; set; } = new();
}
