namespace GerenciamentoDeBiblioteca.Models
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int Pontuacao { get; set; }
        public string Comentario { get; set; }
        public int DataAvaliacao { get; set; }

        public int LivroId { get; set; }
        public virtual LivroModel? Livro { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
