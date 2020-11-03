using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyMovieServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


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
        public List<Pelicula> GetPeliculas()
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            foreach (var pelicula in _context.Pelicula.ToList())
            {
                Console.Out.WriteLine("Hola");
                Pelicula dummy = new Pelicula();
                dummy.AnoPelicula = pelicula.AnoPelicula;
                dummy.Calificacion = pelicula.Calificacion;
                dummy.Director = pelicula.Director;
                dummy.Favorito = pelicula.Favorito;
                dummy.IdEstilo = pelicula.IdEstilo;
                dummy.IdEstiloNavigation = pelicula.IdEstiloNavigation;
                dummy.IdGenero = pelicula.IdGenero;
                dummy.IdGeneroNavigation = pelicula.IdGeneroNavigation;
                dummy.IdIdioma = pelicula.IdIdioma;
                dummy.IdIdiomaNavigation = pelicula.IdIdiomaNavigation;
                dummy.IdPelicula = pelicula.IdPelicula;
                dummy.Imagen = pelicula.Imagen;
                dummy.IndicePopularidad = pelicula.IndicePopularidad;
                dummy.NombrePelicula = pelicula.NombrePelicula;
                dummy.NotaImdb = pelicula.NotaImdb;
                dummy.NotaMetascore = pelicula.NotaMetascore;
                peliculas.Add(dummy);
            }
            return peliculas;
        }
    }
}
