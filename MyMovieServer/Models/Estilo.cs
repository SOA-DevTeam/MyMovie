using System;
using System.Collections.Generic;

namespace MyMovieServer.Models
{
    public partial class Estilo
    {
        public Estilo()
        {
            Pelicula = new HashSet<Pelicula>();
        }

        public int IdEstilo { get; set; }
        public string Estilo1 { get; set; }

        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}
