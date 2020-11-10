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
    [Route("comentar")]
    [ApiController]
    public class ComentarController : ControllerBase
    {
        private ILogger<ComentarController> _logger;
        private MyMovieDBContext _context;
        private LogicaAgregarComentario _logicaComentar = new LogicaAgregarComentario();

        public ComentarController(ILogger<ComentarController> logger, MyMovieDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost()]
        public int Comentar(ComentariosPM data)
        {

            return _logicaComentar.Comentar(data, _context);
        }
        [HttpPut()]
        public int ActualizarPopularidad(PopularidadPM data)
        {

            return _logicaComentar.ActualizarPopularidad(data, _context);
        }

    }
}
