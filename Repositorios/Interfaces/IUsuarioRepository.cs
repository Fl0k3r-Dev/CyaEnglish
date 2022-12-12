using CyaEnglish.Models;

namespace CyaEnglish.Repositorios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetById(Guid id);
        Task<UsuarioModel> Insert(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel user);
        Task<bool> Delete(Guid id);
    }
}
