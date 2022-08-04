using PoupaDev.API.Models;
using Microsoft.AspNetCore.Mvc;
using PoupaDev.API.Context;
using PoupaDev.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace PoupaDev.API.Controllers
{
  [ApiController]
  [Route("api/objectivos-financeiros")]
  public class ObjetivosFinanceirosController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ObjetivosFinanceirosController(AppDbContext context)
    {
      _context = context;
    }

    //api/objectivos-financeiros
    [HttpGet]
    public IActionResult GetTodos()
    {
      var objetivos = _context.Objetivos;

      return Ok(objetivos);
    }

    [HttpGet("{id}")]
    public IActionResult GetPorId(int id)
    {
      var objetivo = _context
      .Objetivos
      .Include(o => o.Operacoes)
      .SingleOrDefault(o => o.Id == id);

      if (objetivo == null)
      {
        return NotFound();
      }

      return Ok(objetivo);
    }

    [HttpPost]
    public IActionResult Post(CreateObjetivoFinanceiroDto dto)
    {
      var objetivo = new ObjetivoFinanceiro(
        dto.Titulo,
        dto.Descricao,
        dto.ValorObjetivo);

      _context.Objetivos.Add(objetivo);
      _context.SaveChanges();

      var id = objetivo.Id;

      return CreatedAtAction("GetPorId", new { id = id }, dto);
    }

    //POST api/objectivos-financeiros/{id}/operacoes
    [HttpPost("{id}/operacoes")]
    public IActionResult PostOperacao(int id, CreateOperacaoDto dto)
    {
      var operacao = new Operacao(
              dto.Valor,
              dto.TipoOperacao,
              id);

      var objetivo = _context
      .Objetivos
      .Include(o => o.Operacoes)
      .SingleOrDefault(o => o.Id == id);

      if (objetivo == null)
      {
        return NotFound();
      }

      objetivo.RealizarOperacao(operacao);
      _context.SaveChanges();

      return NoContent();
    }
  }
}