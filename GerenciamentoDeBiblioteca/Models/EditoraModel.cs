﻿namespace GerenciamentoDeBiblioteca.Models
{
    public class EditoraModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public int AnoFundacao { get; set; }
        public ICollection<LivroModel> Livros { get; set; }
    }
}
