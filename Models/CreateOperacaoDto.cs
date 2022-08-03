using PoupaDev.API.Enums;

namespace PoupaDev.API.Models
{
  public class CreateOperacaoDto
  {
    public decimal Valor { get; set; }
    public TipoOperacao TipoOperacao { get; set; }
  }
}