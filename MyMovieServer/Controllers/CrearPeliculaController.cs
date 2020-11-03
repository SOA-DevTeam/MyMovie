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
    [Route("nuevaPeli")]
    [ApiController]
    public class CrearPeliculaController : ControllerBase
    {
        private ILogger<CrearPeliculaController> _logger;
        private MyMovieDBContext _context;
        private LogicaAgregarPelicula _np= new LogicaAgregarPelicula();

        public CrearPeliculaController(ILogger<CrearPeliculaController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }


    }
}
