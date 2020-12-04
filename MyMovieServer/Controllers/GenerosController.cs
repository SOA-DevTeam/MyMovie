using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;

namespace MyMovieServer.Controllers
{
    [Route("generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private ILogger<GenerosController> _logger;
        private MyMovieDBContext _context;
        private LogicaGeneros _lg = new LogicaGeneros();

        public GenerosController(ILogger<GenerosController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        public List<GenerosPM> GetGPM()
        {
            var result = _lg.ObtenerGeneros(_context);
            return result;
        }
    }
}
