using System;

namespace ApiTransparencia.Domain.Models.Deputados;

public class DeputadosDespesasItemModel
{
    public int Ano { get; set; }
    public int Mes { get; set; }
    public string? TipoDespesa { get; set; }
    public string? CodDocumento { get; set; }
    public string? TipoDocumento { get; set; }
    public int CodTipoDocumento { get; set; }
    public string? DataDocumento { get; set; }
    public string? NumDocumento { get; set; }
    public decimal ValorDocumento { get; set; }
    public string? UrlDocumento { get; set; }
    public string? NomeFornecedor { get; set; }
    public string? CnpjCpfFornecedor { get; set; }
    public decimal ValorLiquido { get; set; }
    public decimal ValorGlosa { get; set; }
    public string? NumRessarcimento { get; set; }
    public long CodLote { get; set; }
    public int Parcela { get; set; }
}
