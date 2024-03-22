using GerenciamentoDeBiblioteca.Enums;

namespace GerenciamentoDeBiblioteca.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }
        public int DataEmprestimo { get; set; }
        public int DataDevolucao { get; set; }
        public StatusEmprestimo StatusE { get; set; }

        public int LivroId { get; set; }
        public virtual LivroModel? Livro { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
