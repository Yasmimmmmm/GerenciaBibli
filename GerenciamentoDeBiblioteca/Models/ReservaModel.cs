using GerenciamentoDeBiblioteca.Enums;

namespace GerenciamentoDeBiblioteca.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public int DataReserva { get; set; }
        public StatusReserva StatusR {  get; set; }

        public int LivroId { get; set; }
        public virtual LivroModel? Livro { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
