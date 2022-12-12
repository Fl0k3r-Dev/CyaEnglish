using CyaEnglish.Data.Map;
using CyaEnglish.Models;
using CyaEnglish.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CyaEnglish.Data
{
    public class CyaEnglishDbContext : DbContext
    {
        public CyaEnglishDbContext(DbContextOptions options)
        : base(options)
        {
             
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        //public DbSet<AlunoViewModel> Aluno { get; set; }
        //public DbSet<AulaViewModel> Aula { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new AlunoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
