using GerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataEmprestimo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataDevolucao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StatusE).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.Livro);
            builder.HasOne(x => x.Usuario);
        }
    }
}
