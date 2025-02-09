using AppAngular.Server.Models;

namespace AppAngular.Server.Repositorio
{
    public interface IRepositorioUsuario
    {
        List<Usuario> GetUsuarios();    
        void CreateUsuario(Usuario usuario);
        void UpdateUsuario(int id, Usuario usuarioActualizado);
        void DeleteUsuario(int id);
        Usuario GetUsuarioById(int id);
    }
}
