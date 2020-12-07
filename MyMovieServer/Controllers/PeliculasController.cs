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
using MyMovieServer.Logic;

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

        [HttpPut("modificar")]
        public IActionResult UpdatePelicula(ModPeliculaPM data)
        {
            var getP = repository.GetPeliMod(data.id);
            if (getP == null)
            {
                return NotFound();
            }
            var pelicula = mapper.ModificarPelicula(getP, data);
            repository.ModificarPelicula(pelicula);
            uow.CompleteAsync();
            return Ok(pelicula);
        }

        [HttpGet("comentarios/{id}")]
        public IActionResult GetComentarios(int id)
        {
            var comentarios = repository.GetCalificacionesByPelicula(id);
            var result = mapper.Comentarios(comentarios);
            return Ok(result);
        }


        [HttpPost("comentarios/nuevo")]
        public IActionResult Comentar(ComentariosPM data)
        {
            var comentario = mapper.AgregarComentario(data);
            repository.AddComentario(comentario);
            uow.CompleteAsync();
            return Ok(comentario);
        }

        [HttpPut("ind_pop")]
        public IActionResult ActualizarPopularidad(PopularidadPM data)
        {
            var getP = repository.GetPeliMod(data.idPelicula);
            if (getP == null)
            {
                return NotFound();
            }
            var pelicula = mapper.ActualizarIndicePop(getP, data);
            repository.ModificarPelicula(pelicula);
            uow.CompleteAsync();
            return Ok(pelicula);
        }

        [HttpGet("rec/{gen}/{comunidad}/{imdb}/{metascore}/{popularidad}/{favorito}")]
        public IActionResult GetPeliculaByRec(int gen, decimal comunidad, decimal imdb, decimal favorito, decimal metascore, decimal popularidad)
        {
            var peliculas = repository.Recomendacion(gen);
            var calificaciones = mapper.Recomendaciones(peliculas);
            var calificacionesPel = new List<CalificacionesDePelicula>();
            LogicaFiltrosRecomendacion logica = new LogicaFiltrosRecomendacion();
            decimal cal;
            foreach (CalificacionesDePelicula pel in calificaciones)
            {
                cal = logica.CalcNotaComunidad(repository.GetCalificacionesByPelicula(pel.IdPelicula));
                pel.Calificacion = cal;
                logica.CalcTotal(pel, calificacionesPel, comunidad, imdb, favorito, metascore, popularidad);
            }
            var result = logica.OrderList(calificacionesPel);
                
            return Ok(result.Take(10));

        }

    }
}
