using Microsoft.Extensions.Logging;
using MyMovieServer.Controllers;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
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
                if (pelicula.IdGenero == id)
                {
                    CalificacionesDePelicula dummy = new CalificacionesDePelicula();
                    dummy.IdGenero = pelicula.IdGenero;
                    dummy.IdPelicula = pelicula.IdPelicula;
                    dummy.Imagen = pelicula.Imagen;
                    dummy.IndicePopularidad = pelicula.IndicePopularidad;
                    dummy.NombrePelicula = pelicula.NombrePelicula;
                    dummy.NotaImdb = pelicula.NotaImdb;
                    dummy.NotaMetascore = pelicula.NotaMetascore;
                    dummy.Favorito = pelicula.Favorito;
                    peliculas.Add(dummy);
                }
            }

            return peliculas;
        }

        public decimal notacomunidad(int idPelicula, MyMovieDBContext context)
        {
            decimal cal = 0.0m;
            int contador = 0;
            foreach(Calificacion c in context.Calificacion.ToList())
            {
                if(c.IdPelicula == idPelicula)
                {
                    cal += c.Calificacion1;
                    contador += 1;
                }
            }
            if(contador != 0) { 
                cal = cal / Convert.ToDecimal(contador);
            }
            return cal;

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
