using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieServer.Repositories;

namespace MyMovieServer.Controllers
{
    [Route("busqueda")]
    [ApiController]
    public class DatosPeliculaController : ControllerBase
    {
        private readonly IBusquedaPeliRepo repository;

        public DatosPeliculaController(IBusquedaPeliRepo repository)
        {
            this.repository = repository;
        }

        [HttpGet("{name}")]
        public IActionResult GetPeliculasByName(String name)
        {
            var peliculas = repository.Busqueda(name);
            return Ok(peliculas);
        }

        [HttpGet("pelicula/{id}")]
        public IActionResult GetPelicula(int id)
        {
            var pelicula = repository.PerfilPelicula(id);
            return Ok(pelicula);
        }
    }
}
