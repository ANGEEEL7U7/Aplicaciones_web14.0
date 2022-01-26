using System;
namespace Pelis.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Correo { get; set; }
        public DateTime Alta { get; set; }
        public bool Activo { get; set; }
        

    }
}