using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Presentation_Model
{
    public class PerfilPeliculaPM
    {
        public int idPelicula { get; set; }
        public string NombrePelicula { get; set; }
        public string AnoPelicula { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public string Idioma { get; set; }
        public string Estilo { get; set; }
        public string Imagen { get; set; }
        public bool Favorito { get; set; }
        public decimal NotaComunidad { get; set; }
        public decimal NotaIMDb { get; set; }
        public decimal NotaMetascore { get; set; }
        public decimal IndicePopularidad { get; set; }
    }

}
