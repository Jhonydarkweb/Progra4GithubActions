using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = new List<object>
            {
                new { Id = 1, Nombre = "Juan" },
                new { Id = 2, Nombre = "Maria" }
            };

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            return Ok(new
            {
                Id = id,
                Nombre = "Usuario Ejemplo"
            });
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] object usuario)
        {
            return Created("", usuario);
        }
    }
}