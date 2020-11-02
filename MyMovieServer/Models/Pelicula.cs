using System;
using System.Collections.Generic;

namespace MyMovieServer.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Calificacion = new HashSet<Calificacion>();
        }

        public int IdPelicula { get; set; }
        public string NombrePelicula { get; set; }
        public string Director { get; set; }
        public int AnoPelicula { get; set; }
        public int IdGenero { get; set; }
        public int IdIdioma { get; set; }
        public decimal? NotaImdb { get; set; }
        public decimal? NotaMetascore { get; set; }
        public bool? Favorito { get; set; }
        public string Imagen { get; set; }
        public int IdEstilo { get; set; }
        public decimal? IndicePopularidad { get; set; }

        public virtual Estilo IdEstiloNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Idioma IdIdiomaNavigation { get; set; }
        public virtual ICollection<Calificacion> Calificacion { get; set; }
    }
}
