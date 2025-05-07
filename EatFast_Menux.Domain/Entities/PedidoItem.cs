using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Entities
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Guid PedidoId { get; set; }  // FK hacia Pedido
    }
}
