using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovieServer.Models;

namespace MyMovieServer.Controllers
{
    [Route("comentar")]
    [ApiController]
    public class ComentarController : ControllerBase
    {
        private ILogger<ComentarController> _logger;
        private MyMovieDBContext _context;

    }
}
