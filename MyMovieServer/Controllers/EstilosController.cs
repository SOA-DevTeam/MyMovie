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
    [Route("estilos")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        private ILogger<EstilosController> _logger;
        private MyMovieDBContext _context;
        private LogicaEstilos _le = new LogicaEstilos();

        public EstilosController(ILogger<EstilosController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        public List<EstilosPM> GetEPM()
        {
            var result = _le.ObtenerEstilos(_context);
            return result;
        }
    }
}
