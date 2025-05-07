using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Rol { get; set; } = "Cliente"; // Roles: Admin, Mesero, Cliente
    }
}
