using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Entities
{
    public class ProductoInventario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int NivelMinimo { get; set; }
        public string UnidadMedida { get; set; } // Ej. "kg", "litros"
        public DateTime FechaUltimaActualizacion { get; set; }
    }
}
