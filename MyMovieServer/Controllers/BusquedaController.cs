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
        private readonly LogicaBusqueda logicaBusqueda;

        public BusquedaController()
        {
            logicaBusqueda = new LogicaBusqueda();
        }

        [HttpGet("{name}")]
        public List<PMPelicula> GetGenero(String name)
        {
            
            return logicaBusqueda.getMovies(name);
        }

    }
}
