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
    [Route("modificar")]
    [ApiController]
    public class ModificarController : ControllerBase
    {
        private ILogger<ModificarController> _logger;
        private MyMovieDBContext _context;
        private LogicaModificacion _mod = new LogicaModificacion();

        public ModificarController(ILogger<ModificarController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPut()]
        public int PutP(ModPeliculaPM data)
        {
            var result = _mod.ModificarDatos(data, _context);
            Console.WriteLine(result);
            return result;
        }
    }
}
