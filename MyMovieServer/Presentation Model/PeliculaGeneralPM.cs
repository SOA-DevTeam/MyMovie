using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Presentation_Model
{
    public class PeliculaGeneralPM
    {
        public int idPelicula { get; set; }
        public string NombrePelicula { get; set; }
        public string AnoPelicula { get; set; }
        public string Director { get; set; }
        public decimal NotaComunidad { get; set; }
    }
}
