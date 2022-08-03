using PoupaDev.API.Entities;

namespace PoupaDev.API.Context
{
  public class AppDbContext
  {
    public List<ObjetivoFinanceiro> Objetivos { get; set; }

    public AppDbContext()
    {
      Objetivos = new List<ObjetivoFinanceiro>();
    }
  }
}