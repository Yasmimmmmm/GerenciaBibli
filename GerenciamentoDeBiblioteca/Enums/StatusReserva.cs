using System.ComponentModel;

namespace GerenciamentoDeBiblioteca.Enums
{
    public enum StatusReserva
    {
        [Description("Reservado")]
        Reservado = 1,

        [Description("Não Reservado")]
        NãoReservado = 2
    }
}
