namespace ApiTransparencia.Domain.Models.Deputados;

public class ListaDeputadosRequestModel
{
    public string? Nome { get; set; }
    public List<string>? SiglaUF { get; set; }
    public List<string>? SiglaPartido { get; set; }
    public List<string>? SiglaSexo { get; set; }
    public string? Ordem { get; set; } = "ASC";
    public string? OrdenarPor { get; set; } = "nome";
}