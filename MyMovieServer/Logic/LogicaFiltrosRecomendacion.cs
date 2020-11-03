using Microsoft.Extensions.Logging;
using MyMovieServer.Controllers;
using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaFiltrosRecomendacion
    {
        public List<Pelicula> getPeliculas(MyMovieDBContext context)
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            foreach (Pelicula pelicula in context.Pelicula.ToList())
            {
                Pelicula dummy = new Pelicula();
                dummy.AnoPelicula = pelicula.AnoPelicula;
                dummy.Calificacion = pelicula.Calificacion;
                dummy.Director = pelicula.Director;
                dummy.Favorito = pelicula.Favorito;
                dummy.IdEstilo = pelicula.IdEstilo;
                dummy.IdEstiloNavigation = pelicula.IdEstiloNavigation;
                dummy.IdGenero = pelicula.IdGenero;
                dummy.IdGeneroNavigation = pelicula.IdGeneroNavigation;
                dummy.IdIdioma = pelicula.IdIdioma;
                dummy.IdIdiomaNavigation = pelicula.IdIdiomaNavigation;
                dummy.IdPelicula = pelicula.IdPelicula;
                dummy.Imagen = pelicula.Imagen;
                dummy.IndicePopularidad = pelicula.IndicePopularidad;
                dummy.NombrePelicula = pelicula.NombrePelicula;
                dummy.NotaImdb = pelicula.NotaImdb;
                dummy.NotaMetascore = pelicula.NotaMetascore;
                peliculas.Add(dummy);
            }

            return peliculas;
    }
    }
}
