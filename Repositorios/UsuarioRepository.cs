using CyaEnglish.Data;
using CyaEnglish.Models;
using CyaEnglish.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyaEnglish.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CyaEnglishDbContext _dbContext;
        public UsuarioRepository(CyaEnglishDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(Guid id)
        {
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if(usuario == null)
                throw new Exception($"Método 'GetById': \nUsuário de ID: {id}. Não encontrado! ");
            return usuario;
        }

        public async Task<UsuarioModel> Insert(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel user, Guid id)
        {
            UsuarioModel usuario = await GetById(id);
            if (usuario == null)
                throw new Exception($"Método 'Update': \nUsuário de ID: {id}. Não encontrado! ");
            _dbContext.Usuarios.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(Guid id)
        {
            UsuarioModel usuario = await GetById(id);
            if (usuario == null)
                throw new Exception($"Método 'Delete': \nUsuário de ID: {id}. Não encontrado! ");
            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
