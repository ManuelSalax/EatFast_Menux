using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string ClienteNombre { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public ICollection<PedidoItem> Items { get; set; } = new List<PedidoItem>();

        public decimal CalcularTotal()
        {
            return Items.Sum(item => item.Cantidad * item.Precio);
        }
    }
}
