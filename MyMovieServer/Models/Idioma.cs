using System;
using System.Collections.Generic;

namespace MyMovieServer.Models
{
    public partial class Idioma
    {
        public Idioma()
        {
            Pelicula = new HashSet<Pelicula>();
        }

        public int IdIdioma { get; set; }
        public string Idioma1 { get; set; }

        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}
