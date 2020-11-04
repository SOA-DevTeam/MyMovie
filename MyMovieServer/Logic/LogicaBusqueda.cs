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
        private readonly MyMovieDBContext context;
        public LogicaBusqueda()
        {
            this.context = new MyMovieDBContext();
        }

        public List<PMPelicula> getMovies(string name)
        {
            List<PMPelicula> peliculas = new List<PMPelicula>();
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
                PMPelicula spelicula = new PMPelicula();
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
