using System;

namespace ApiTransparencia.Domain.Models;

public class DeputadoUltimoStatusModel
{
    public int Id { get; set; }
    public string? Uri { get; set; }
    public string? Nome { get; set; }
    public string? SiglaPartido { get; set; }
    public string? UriPartido { get; set; }
    public string? SiglaUf { get; set; }
    public int IdLegislatura { get; set; }
    public string? UrlFoto { get; set; }
    public string? Email { get; set; }
    public string? Data { get; set; }
    public string? NomeEleitoral { get; set; }
    public DeputadoGabineteModel? Gabinete { get; set; }
    public string? Situacao { get; set; }
    public string? CondicaoEleitoral { get; set; }
    public string? DescricaoStatus { get; set; }
}
