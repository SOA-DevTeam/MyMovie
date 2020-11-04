using Microsoft.Extensions.Logging;
using MyMovieServer.Controllers;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaFiltrosRecomendacion
    {
        public List<CalificacionesDePelicula> getPeliculas(MyMovieDBContext context, int id)
        {
            List<CalificacionesDePelicula> peliculas = new List<CalificacionesDePelicula>();
            foreach (Pelicula pelicula in context.Pelicula.ToList())
            {   
                if(pelicula.IdGenero == id)
                {
                    CalificacionesDePelicula dummy = new CalificacionesDePelicula();
                    dummy.IdGenero = pelicula.IdGenero;
                    dummy.IdPelicula = pelicula.IdPelicula;
                    dummy.Imagen = pelicula.Imagen;
                    dummy.IndicePopularidad = pelicula.IndicePopularidad;
                    dummy.NombrePelicula = pelicula.NombrePelicula;
                    dummy.NotaImdb = pelicula.NotaImdb;
                    dummy.NotaMetascore = pelicula.NotaMetascore;
                    peliculas.Add(dummy);
                }
            }

            return peliculas;
        }

        public List<Genero> getGen(MyMovieDBContext _context)
        {
            List<Genero> generos = new List<Genero>();
            foreach (Genero gen in _context.Genero.ToList())
            {
                generos.Add(gen);
            }
            return generos;
        }
    }
}
