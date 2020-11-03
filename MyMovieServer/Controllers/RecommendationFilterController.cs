using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyMovieServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovieServer.Logic;

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
            LogicaFiltrosRecomendacion get = new LogicaFiltrosRecomendacion();
            peliculas = get.getPeliculas(_context);
            return peliculas;
        }
    }
}
