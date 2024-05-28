using BuyCar.Context;
using BuyCar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyCar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public AdministradoresController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Administrador>> Get()
        {
            var admins = _context.Administradores.ToList();
            if (admins is null)
            {
                return NotFound();
            }
            return admins;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Administrador admins)
        {
            _context.Administradores.Add(admins);
            _context.SaveChanges();

            return Ok("Criado com sucesso!");
        }
    }
}
