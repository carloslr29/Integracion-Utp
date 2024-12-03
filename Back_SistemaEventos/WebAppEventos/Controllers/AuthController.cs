using Eventos.Entidades;
using Eventos.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UsuariosService _userService;

        public AuthController(UsuariosService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuarios request)
        {
            var user = _userService.Authenticate(request.Correo, request.Contrasena);
            if (user == null)
                return Unauthorized(new { message = "Usuario o contraseña incorrectos" });

            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Usuarios request)
        {
            _userService.Register(request.Nombre, request.Correo, request.Contrasena, request.Rol);
            return Ok(new { message = "Usuario registrado con éxito" });
        }
    }
}
