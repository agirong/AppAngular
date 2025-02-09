using AppAngular.Server.Models;
using AppAngular.Server.Repositorio;
using AppAngular.Server.Servicio;
using Microsoft.EntityFrameworkCore;

namespace AppAngular.Server.ServicioImp
{
    public class ServicioUsuarioImp: IServicioUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicioUsuarioImp(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public List<Usuario> GetUsers()
        {
            try
            {
                List<Usuario> list = _repositorioUsuario.GetUsuarios();
                if (list == null)
                {
                    return null;
                }
                else 
                {
                    return list;    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un errror...");
            }
        }

        public void CreateUser(Usuario usuario)
        {
            try
            {
                _repositorioUsuario.CreateUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(int id, Usuario usuarioActualizado)
        {
            try
            {
                _repositorioUsuario.UpdateUsuario(id, usuarioActualizado);  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _repositorioUsuario.DeleteUsuario(id);  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario GetUserById(int id)
        {
            try
            {
                return _repositorioUsuario.GetUsuarioById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
