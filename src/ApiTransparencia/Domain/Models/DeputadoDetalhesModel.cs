using System;

namespace ApiTransparencia.Domain.Models;

public class DeputadoDetalhesModel
{
    public int Id { get; set; }
    public string? Uri { get; set; }
    public string? NomeCivil { get; set; }
    public DeputadoUltimoStatusModel? UltimoStatus { get; set; }
    public string? Cpf { get; set; }
    public string? Sexo { get; set; }
    public string? UrlWebsite { get; set; }
    public List<string> RedeSocial { get; set; } = new();
    public string? DataNascimento { get; set; }
    public string? DataFalecimento { get; set; }
    public string? UfNascimento { get; set; }
    public string? MunicipioNascimento { get; set; }
    public string? Escolaridade { get; set; }
}
