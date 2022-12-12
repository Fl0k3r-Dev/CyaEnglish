using CyaEnglish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace CyaEnglish.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StAtivo).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ConfirmEmail).IsRequired().HasMaxLength(1);

        }
    }
}
