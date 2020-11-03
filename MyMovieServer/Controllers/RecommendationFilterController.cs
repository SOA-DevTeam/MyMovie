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
        private readonly ILogger<RecommendationFilterController> _logger;
        private readonly MyMovieDBContext _context;

        public RecommendationFilterController(ILogger<RecommendationFilterController> logger, MyMovieDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("get")]
        public List<CalificacionesDePelicula> GetPeliculas(int imdb, int metascore, int popularidad)
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            List<CalificacionesDePelicula> calificaciones = new List<CalificacionesDePelicula>();
            LogicaFiltrosRecomendacion get = new LogicaFiltrosRecomendacion();
            peliculas = get.getPeliculas(_context);
            System.Collections.IList list = peliculas;
            for (int i = 0; i < list.Count; i++)
            {
                CalificacionesDePelicula pel = new CalificacionesDePelicula();
                pel.IdGenero = peliculas[i].IdGenero;
                pel.IdPelicula = peliculas[i].IdPelicula;
                pel.Imagen = peliculas[i].Imagen;
                pel.IndicePopularidad = peliculas[i].IndicePopularidad;
                pel.NombrePelicula = peliculas[i].NombrePelicula;
                pel.NotaImdb = peliculas[i].NotaImdb;
                pel.NotaMetascore = peliculas[i].NotaMetascore;
                calificaciones.Add(pel);
            }
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