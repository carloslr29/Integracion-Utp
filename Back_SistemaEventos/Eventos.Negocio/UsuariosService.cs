using Eventos.Datos;
using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio
{
    public class UsuariosService
    {
        private readonly UsuariosRepository _userRepository;

        public UsuariosService(UsuariosRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Usuarios Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) return null;

            var hashedPassword = HashPassword(password);
            if (user.Contrasena != hashedPassword) return null;

            return new Usuarios
            {
                UsuarioID = user.UsuarioID,
                Correo = user.Correo
            };
        }

        public void Register(string nombre, string correo, string contrasena, string rol)
        {
            var hashedPassword = HashPassword(contrasena);
            var user = new Usuarios { Nombre = nombre, Correo = correo, Contrasena = hashedPassword, Rol = rol };
            _userRepository.agregarUsuario(user);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
