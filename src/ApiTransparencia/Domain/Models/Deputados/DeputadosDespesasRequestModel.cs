using System;

namespace ApiTransparencia.Domain.Models.Deputados;

public class DeputadosDespesasRequestModel
{
    public int? Id { get; set; }
    public List<string>? IdLegislatura { get; set; }
    public List<string>? Ano { get; set; }
    public List<string>? Mes { get; set; }
    public string? CnpjCpfFornecedor { get; set; }
    public string? Pagina { get; set; }
    public string? Itens { get; set; }
    public string? Ordem { get; set; } = "ASC";
    public string? OrdenarPor { get; set; } = "ano";
}
