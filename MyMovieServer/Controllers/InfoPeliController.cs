using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieServer.Mapping;
using MyMovieServer.Presentation_Model;
using MyMovieServer.Repositories;

namespace MyMovieServer.Controllers
{
    [Route("info_peli")]
    [ApiController]
    public class InfoPeliController : ControllerBase
    {
        private readonly IInfoPeliRepo repository;
        private readonly IKeyValueMap mapper;

        public InfoPeliController(IInfoPeliRepo repository, IKeyValueMap mapper )
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("generos")]
        public  IActionResult GetGPM()
        {
            var generos = repository.GetGeneros();
            if (generos == null)
            {
                return NotFound();
            }
            
            var genPM = mapper.GenerosMap(generos);
            return Ok(genPM);   
        }

        [HttpGet("idiomas")]
        public IActionResult GetIPM()
        {
            var idiomas = repository.GetIdiomas();
            if (idiomas == null)
            {
                return NotFound();
            }

            var iPM = mapper.IdiomasMap(idiomas);
            return Ok(iPM);
        }


        [HttpGet("estilos")]
        public IActionResult GetEPM()
        {
            var estilos = repository.GetEstilos();
            if (estilos == null)
            {
                return NotFound();
            }

            var ePM = mapper.EstilosMap(estilos);
            return Ok(ePM);
        }
    }
}
