using GerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<ReservaModel>
    {
        public void Configure(EntityTypeBuilder<ReservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataReserva).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StatusR).IsRequired().HasMaxLength(255);
        }
    }
}
