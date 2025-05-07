using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Entities
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public string NombreCliente { get; set; } = null!;
        public DateTime FechaReserva { get; set; }
        public int CantidadPersonas { get; set; }
        public string? Telefono { get; set; }
        public string? Observaciones { get; set; }
    }
}
