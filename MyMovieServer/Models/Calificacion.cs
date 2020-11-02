using System;
using System.Collections.Generic;

namespace MyMovieServer.Models
{
    public partial class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int IdPelicula { get; set; }
        public decimal Calificacion1 { get; set; }
        public string Comentario { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; }
    }
}
