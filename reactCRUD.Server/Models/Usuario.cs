using System;
using System.Collections.Generic;

namespace reactCRUD.Server.Models
{
    public partial class Usuario
    {
        public int IdUser { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
    }
}
