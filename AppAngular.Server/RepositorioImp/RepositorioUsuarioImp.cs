using AppAngular.Server.Models;
using AppAngular.Server.Repositorio;

namespace AppAngular.Server.RepositorioImp
{
    public class RepositorioUsuarioImp : IRepositorioUsuario
    {
        private readonly ModelContext _context;

        public RepositorioUsuarioImp(ModelContext context)
        {
            _context = context; 
        }

        public List<Usuario> GetUsuarios() 
        {
            try
            {
                return _context.Usuarios.ToList();  
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);                
            }
        }

        public void CreateUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUsuario(int id, Usuario usuarioActualizado)
        {
            try
            {
                var usuarioExistente = _context.Usuarios.Find(id);
                if (usuarioExistente == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                // Actualiza las propiedades del usuario existente
                usuarioExistente.Nombre = usuarioActualizado.Nombre;
                usuarioExistente.Apellido = usuarioActualizado.Apellido;
                usuarioExistente.Email = usuarioActualizado.Email;
                usuarioExistente.Contrasena = usuarioActualizado.Contrasena;
                usuarioExistente.Estado = usuarioActualizado.Estado;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUsuario(int id)
        {
            try
            {
                var usuarioExistente = _context.Usuarios.Find(id);
                if (usuarioExistente == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                _context.Usuarios.Remove(usuarioExistente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

    }
}
