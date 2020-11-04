using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Presentation_Model
{
    public class CalificacionesDePelicula
    {
        public int IdPelicula { get; set; }
        public string NombrePelicula { get; set; }
        public int IdGenero { get; set; }
        public decimal? NotaImdb { get; set; }
        public decimal? NotaMetascore { get; set; }
        public string Imagen { get; set; }
        public decimal? IndicePopularidad { get; set; }
        public decimal? Calificacion { get; set; }
        public decimal? Total { get; set; }
        public bool? Favorito { get; set; }
    }
}
