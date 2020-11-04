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
        [HttpGet("get/{gen}/{imdb}/{metascore}/{popularidad}/{comunida}")]
        public List<CalificacionesDePelicula> GetPeliculas(int gen, int imdb, int metascore, int popularidad, int comunidad)
        {
            List<CalificacionesDePelicula> calificaciones = new List<CalificacionesDePelicula>();
            LogicaFiltrosRecomendacion get = new LogicaFiltrosRecomendacion();
            calificaciones = get.getPeliculas(_context, gen);
            return calificaciones;
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