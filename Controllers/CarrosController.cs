using BuyCar.Context;
using BuyCar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyCar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CarrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("C")]
        public ActionResult<IEnumerable<object>> GetCarrosComNomesUsuarios()
        {
            var carrosComNomesUsuarios = _context.Carros
                .Select(c => new
                {
                    c.Id,
                    c.Foto,
                    c.Modelo,
                    c.Marca,
                    c.Cor,
                    c.Descricao,
                    c.Placa,
                    c.Preco,
                    UsuarioNome = c.Usuario.Nome 
                })
                .ToList();

            return carrosComNomesUsuarios;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Carro>> Get()
        {
            var carros = _context.Carros.ToList();
            if(carros is null)
            {
                return NotFound("Usuario nao encontrado");
            }
            return carros;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Carro carro)
        {
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return Ok();
        }

    }

}
