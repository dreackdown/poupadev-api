namespace PoupaDev.API.Models
{
  public class CreateObjetivoFinanceiroDto
  {
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public decimal? ValorObjetivo { get; set; }
  }
}