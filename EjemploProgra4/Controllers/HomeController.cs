using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        // Simulación de base de datos
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Juan" },
            new Usuario { Id = 2, Nombre = "Maria" }
        };

        // GET: api/usuarios
        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            return Ok(usuarios);
        }

        // GET: api/usuarios/1
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario nuevoUsuario)
        {
            // Generar ID automático
            int nuevoId = usuarios.Max(u => u.Id) + 1;

            nuevoUsuario.Id = nuevoId;

            usuarios.Add(nuevoUsuario);

            return CreatedAtAction(
                nameof(ObtenerUsuario),
                new { id = nuevoUsuario.Id },
                nuevoUsuario
            );
        }
    }

    // Modelo
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}