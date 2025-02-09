using AppAngular.Server.Models;

namespace AppAngular.Server.Servicio
{
    public interface IServicioUsuario
    {
        List<Usuario> GetUsers();
        void CreateUser(Usuario usuario);
        void UpdateUser(int id, Usuario usuarioActualizado);
        void DeleteUser(int id);
        Usuario GetUserById(int id);
    }
}
