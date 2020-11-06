using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyMovieServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovieServer.Logic;
using MyMovieServer.Presentation_Model;
using System.Net.Security;

namespace MyMovieServer.Controllers
{

    [Route("rf")]
    [ApiController]
    public class RecommendationFilterController : ControllerBase
    {
        private readonly MyMovieDBContext _context;

        public RecommendationFilterController( MyMovieDBContext context)
        {
            _context = context;
        }
        [HttpGet("get/{gen}/{comunidad}/{imdb}/{metascore}/{popularidad}/{favorito}")]
        public IEnumerable<CalificacionesDePelicula> GetPeliculas(int gen, decimal comunidad, decimal imdb, decimal favorito, decimal metascore, decimal popularidad)
        {
            List<CalificacionesDePelicula> calificaciones = new List<CalificacionesDePelicula>();
            LogicaFiltrosRecomendacion get = new LogicaFiltrosRecomendacion();
            List<CalificacionesDePelicula> calificacionesPel = new List<CalificacionesDePelicula>();
            calificaciones = get.getPeliculas(_context, gen);
            decimal cal;
            foreach (CalificacionesDePelicula pel in calificaciones)
            {
                cal = get.notacomunidad(pel.IdPelicula, _context);
                pel.Calificacion = cal;
                pel.Total = pel.Calificacion * (comunidad * 0.01m) +
                    pel.NotaMetascore * (metascore * 0.01m) +
                    pel.NotaImdb * (imdb * 0.01m) +
                    (Convert.ToInt32(pel.Favorito) * 10) * (favorito * 0.01m)
                    + pel.IndicePopularidad * (popularidad * 0.01m);
                calificacionesPel.Add(pel);
            }
            IEnumerable<CalificacionesDePelicula> peliculaCalificadas =
                from p in calificacionesPel orderby p.Total descending select p ;
            return peliculaCalificadas.Take(10);
        }

        [HttpGet("cal")]
        public List<Calificacion> getCal()
        {
            List<Calificacion> cals = new List<Calificacion>();
            foreach (Calificacion c in _context.Calificacion.ToList())
            {
                cals.Add(c);
            }
            return cals;
        }

        [HttpGet ("gen")]
        public List<Genero> GetGen()
        {
            List<Genero> generos = new List<Genero>();
            LogicaFiltrosRecomendacion logic = new LogicaFiltrosRecomendacion();
            generos = logic.getGen(_context);
            return generos;
        }
    }
}