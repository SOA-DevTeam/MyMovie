using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MyMovieServer.Presentation_Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyMovieServer.Logic
{

    public class LogicaBusqueda
    {
        public LogicaBusqueda()
        {
        }

        public List<PeliculaGeneralPM> getMovies(string name, MyMovieDBContext context)
        {
            List<PeliculaGeneralPM> peliculas = new List<PeliculaGeneralPM>();
            var pelicula = (from peli in context.Pelicula
                            join cali in context.Calificacion 
                            on peli.IdPelicula equals cali.IdPelicula into joined
                            from joi in joined.DefaultIfEmpty()
                            where peli.NombrePelicula.Contains(name)
                            group joi by new { peli. IdPelicula, peli.NombrePelicula, peli.Director, peli.AnoPelicula} into gr
                          select new
                          {
                              idPelicula = gr.Key.IdPelicula,
                              NombrePelicula = gr.Key.NombrePelicula,
                              Director = gr.Key.Director,
                              AnoPelicula = gr.Key.AnoPelicula,
                              Promedio = gr.Average(x => x.Calificacion1)
                          }).ToList();
           

            int i = 0;
            foreach (var p in pelicula)
            {
                PeliculaGeneralPM spelicula = new PeliculaGeneralPM();
                spelicula.idPelicula = pelicula.ElementAt(i).idPelicula;
                spelicula.NombrePelicula = pelicula.ElementAt(i).NombrePelicula;
                spelicula.Director = pelicula.ElementAt(i).Director;
                spelicula.AnoPelicula = pelicula.ElementAt(i).AnoPelicula;
                spelicula.NotaComunidad = pelicula.ElementAt(i).Promedio;
                peliculas.Add(spelicula);
                i++;

            }
            return peliculas;
        }

    }
}
