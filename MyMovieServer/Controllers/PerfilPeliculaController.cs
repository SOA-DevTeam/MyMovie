using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;

namespace MyMovieServer.Controllers
{
    [Route("pelicula")]
    [ApiController]
    public class PerfilPeliculaController : ControllerBase
    {
        private ILogger<BusquedaController> _logger;
        private MyMovieDBContext _context;
        private LogicaPerfilPelicula _logicaPelicula = new LogicaPerfilPelicula();

        public PerfilPeliculaController(ILogger<BusquedaController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("{id}")]
        public PerfilPeliculaPM GetGenero(int id)
        {

            return _logicaPelicula.GetMovie(id, _context);
        }
    }
}
