using GerenciamentoDeBiblioteca.Data.Map;
using GerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data
{
    public class GerenciamentoDeBibliotecaDbContext : DbContext
    {
        public GerenciamentoDeBibliotecaDbContext(DbContextOptions<GerenciamentoDeBibliotecaDbContext> options)
            : base(options)
        {
        } 
        public DbSet<AutorModel> Autor { get; set; }
        public DbSet<AvaliacaoModel> Avaliacao { get; set; }
        public DbSet<EditoraModel> Editora { get; set; }
        public DbSet<EmprestimoModel> Emprestimo { get; set; }
        public DbSet<LivroModel> Livro { get; set; }
        public DbSet<ReservaModel> Reserva { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
