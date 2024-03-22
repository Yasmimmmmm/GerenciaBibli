using GerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnoPubli).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Sinopse).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(255);
        }
    }
}
