using BuyCar.Context;
using BuyCar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyCar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly AppDbContext _context;

            public ComprasController(AppDbContext context)
            {
                _context = context;
            }

            [HttpPost]
            public ActionResult Post([FromBody] Compra compra)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();

                return StatusCode(201);
            }
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var compras = _context.Compras
                .Include(c => c.Usuario)
                .Include(c => c.Carro)
                .Select(c => new
                {
                    c.Id,
                    c.DataCompra,
                    c.UsuarioId,
                    c.CarroId,
                    c.PrecoFinal,
                    NomeUsuario = c.Usuario != null ? c.Usuario.Nome : null,
                    NomeCarro = c.Carro != null ? c.Carro.Modelo : null
                })
                .ToList();

            if (compras == null || !compras.Any())
            {
                return NotFound();
            }

            return Ok(compras);
        }
    }
}
