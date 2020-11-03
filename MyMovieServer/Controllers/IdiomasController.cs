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
    [Route("idiomas")]
    [ApiController]
    public class IdiomasController : ControllerBase
    {
        private ILogger<IdiomasController> _logger;
        private MyMovieDBContext _context;
        private LogicaIdiomas _li = new LogicaIdiomas();

        public IdiomasController(ILogger<IdiomasController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet()]
        public List<IdiomasPM> GetIPM()
        {
            var result = _li.ObtenerIdiomas(_context);
            return result;
        }
    }
}
