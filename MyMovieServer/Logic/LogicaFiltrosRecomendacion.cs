using Microsoft.Extensions.Logging;
using MyMovieServer.Controllers;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaFiltrosRecomendacion
    {

        public decimal CalcNotaComunidad(List<Calificacion> calificaciones)
        {
            decimal cal = 0.0m;
            foreach (Calificacion c in calificaciones)
            {
                    cal += c.Calificacion1;
            }
            if (calificaciones.Count != 0)
            {
                cal /= Convert.ToDecimal(calificaciones.Count);
            }
            return cal;
        }

        public void CalcTotal(CalificacionesDePelicula pel, List<CalificacionesDePelicula> calList, decimal comunidad, decimal imdb, decimal favorito, decimal metascore, decimal popularidad)
        {
            pel.Total = pel.Calificacion * (comunidad * 0.1m) +
            pel.NotaMetascore * (metascore * 0.1m) +
            pel.NotaImdb * (imdb * 0.1m) +
            (Convert.ToInt32(pel.Favorito) * 100) * (favorito * 0.01m)
            + pel.IndicePopularidad * (popularidad * 0.01m);
            calList.Add(pel);
        }

        public IEnumerable<CalificacionesDePelicula> OrderList(List<CalificacionesDePelicula> list)
        {
            IEnumerable<CalificacionesDePelicula> peliculaCalificadas = from p in list orderby p.Total descending select p;
            return peliculaCalificadas;
        }
        
    }
}
