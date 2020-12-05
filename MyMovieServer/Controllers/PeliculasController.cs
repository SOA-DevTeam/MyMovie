using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieServer.Presentation_Model;
using MyMovieServer.Mapping;
using MyMovieServer.Repositories;
using MyMovieServer.UoW;




namespace MyMovieServer.Controllers
{
    [Route("peliculas")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculasRepo repository;
        private readonly IUnitOfWork uow;
        private readonly IPeliculaMap mapper;

        public PeliculasController(IPeliculasRepo repository, IUnitOfWork uow, IPeliculaMap mapper)
        {
            this.repository = repository;
            this.uow = uow;
            this.mapper = mapper;
        }
        
        [HttpPost("agregar")]
        public IActionResult AddPelicula(NuevaPeliculaPM data)
        {
            var peliMap = mapper.NuevaPelicula(data);
            repository.AgregarPelicula(peliMap);
            uow.CompleteAsync();
            return Ok(peliMap);
        }

        [HttpPut("modificar/{id}")]
        public IActionResult UpdatePelicula(ModPeliculaPM data, int id)
        {
            var getP = repository.GetPeliMod(id);
            if (getP == null)
            {
                return NotFound();
            }
            var pelicula = mapper.ModificarPelicula(getP, data);
            repository.ModificarPelicula(pelicula);
            uow.CompleteAsync();
            return Ok(pelicula);
        }
    }
}
