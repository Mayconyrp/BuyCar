using BuyCar.Context;
using BuyCar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyCar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("CarroUsuario")]
        public ActionResult<IEnumerable<Usuario>> GetCarrosUsuarios()
        {
            return _context.Usuarios.Include(u => u.Carros).ToList();
        }

    

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _context.Usuarios.ToList();
            if (usuarios is null)
            {
                return NotFound();
            }
            return usuarios;
        }
        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault
                (u => u.Id == id);
            if (usuario is null)
            {
                return NotFound("Usuario nao encontrado");
            }
            return usuario;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario", new { id = usuario.Id }, usuario);

        }
        [HttpPut("{id:int}")]           
        public ActionResult Put(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(usuario);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario is null)
            {
                return NotFound("Usuario nao localizado...");
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

    }
}
