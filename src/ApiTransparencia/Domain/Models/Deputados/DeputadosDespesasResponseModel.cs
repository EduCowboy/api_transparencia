using System;

namespace ApiTransparencia.Domain.Models.Deputados;

public class DeputadosDespesasResponseModel
{
    public List<DeputadosDespesasItemModel> Dados { get; set; } = new();
    public List<LinksModel> Links { get; set; } = new();
}
