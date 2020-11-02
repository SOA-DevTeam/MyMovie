using System;
using System.Collections.Generic;

namespace MyMovieServer.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Pelicula = new HashSet<Pelicula>();
        }

        public int IdGenero { get; set; }
        public string Genero1 { get; set; }

        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}
