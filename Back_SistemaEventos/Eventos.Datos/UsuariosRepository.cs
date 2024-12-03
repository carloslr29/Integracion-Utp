using Eventos.Entidades;

namespace Eventos.Datos
{
    public class UsuariosRepository
    {
        private readonly ConexionBD _context;

        public UsuariosRepository(ConexionBD context)
        {
            _context = context;
        }

        public Usuarios GetUserByUsername(string username)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Correo == username);
        }

        public void agregarUsuario(Usuarios user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }
    }
}
