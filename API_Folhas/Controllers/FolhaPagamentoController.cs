    using System.Linq;
    using API.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using API_FOlhas.Models;
    

namespace API.Controllers
{
    [ApiController]
    [Route("api/folha")]

    public class FolhaPagamentoController : ControllerBase
    {
        private readonly DataContext _context;

          public FolhaPagamentoController(DataContext context) =>
            _context = context;


        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha Folha)
        {
            var funcionarios = _context.Funcionarios.FirstOrDefault(f => f.Cpf == CadastroFolha.Cpf);
            if (funcionarios != null){
                var folha = new FolhaPagamento {
                    funcionario = funcionarios,
                    valorHora = Folha.valorHora,
                    quantidadeHoras = Folha.quantidadeHoras,
                    mes = Folha.mes,
                    ano = Folha.ano
                    
                };
                _context.Folhas.Add(folha);
                _context.SaveChanges();
                return Created("", folha);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Folhas.Include(x => x.funcionario).ToList());

        [HttpGet]
        [Route("buscar/{Cpf}/{mes}/{ano}")]
        public IActionResult Buscar([FromRoute] string Cpf, int mes, int ano)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(u => u.Cpf.Equals(Cpf));
            if (funcionario != null){
                var folha = _context.Folhas.Include( f => f.funcionario).Where(f => f.ano == ano  && f.mes == mes);
                return Ok(folha);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("filtrar/{mes}/{ano}")]
        public IActionResult Filtrar([FromRoute] int mes, int ano)
        {
            var folha = _context.Folhas.Include(f => f.funcionario).Where(f => f.ano == ano  && f.mes == mes);
            return Ok(folha);

        }
    }

}