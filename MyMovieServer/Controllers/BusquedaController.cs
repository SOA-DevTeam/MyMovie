using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using Microsoft.Extensions.Logging;

namespace MyMovieServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private ILogger<BusquedaController> _logger;
        private MyMovieDBContext _context;
        private LogicaBusqueda _logicaBusqueda = new LogicaBusqueda();

        public BusquedaController(ILogger<BusquedaController> logger,  MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{name}")]
        public List<PeliculaGeneralPM> GetGenero(String name)
        {
            
            return _logicaBusqueda.getMovies(name, _context);
        }

    }
}
