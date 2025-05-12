using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Entities
{
    public class PedidoDomicilio
    {
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public string DireccionEntrega { get; set; }
        public EstadoDomicilio Estado { get; set; } // EnCamino, Entregado, Cancelado
        public Guid RepartidorId { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }

    public enum EstadoDomicilio
    {
        Pendiente,
        EnCamino,
        Entregado,
        Cancelado
    }

    public class Repartidor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
    }

}
