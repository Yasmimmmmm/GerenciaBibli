using System.ComponentModel;

namespace GerenciamentoDeBiblioteca.Enums
{
    public enum StatusEmprestimo
    {
        [Description("Disponível")]
        Disponivel = 1,

        [Description("Aguardando")]
        Aguardando = 2,

        [Description("Emprestado")]
        Emprestado = 3,
    }
}
