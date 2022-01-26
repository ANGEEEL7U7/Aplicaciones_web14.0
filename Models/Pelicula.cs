using System;

namespace Pelis.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Director { get; set; }
        public String Genero { get; set; }
        public double Puntuacion { get; set; }
        public int Rating { get; set; }
        public DateTime Fecha { get; set; }

    }
}