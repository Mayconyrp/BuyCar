using BuyCar.Context;
using BuyCar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuyCar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DenunciasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DenunciasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Denuncia denuncia)
        {
            _context.Denuncias.Add(denuncia);
            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var denuncias = _context.Denuncias
                .Include(d => d.Usuario)
                .Include(d => d.Carro)
                .Select(d => new
                {
                    d.Id,
                    d.Motivo,
                    d.Data_Hora,
                    d.Status,
                    d.UsuarioId,
                    d.CarroId,
                    NomeUsuario = d.Usuario != null ? d.Usuario.Nome : null,
                    NomeCarro = d.Carro != null ? d.Carro.Modelo : null
                })
                .ToList();

            if (denuncias == null || !denuncias.Any())
            {
                return NotFound();
            }
            return Ok(denuncias);
        }
    }
}
