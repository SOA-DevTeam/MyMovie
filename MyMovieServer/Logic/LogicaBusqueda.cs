using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MyMovieServer.Presentation_Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyMovieServer.Logic
{
    public interface ILogicaBusqueda
    {
        public List<PMPelicula> getMovies(string name);
        
    }

    public class LogicaBusqueda : ILogicaBusqueda
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
                            where peli.NombrePelicula.Contains(name)
                          select new
                          {
                              idPelicula = peli.IdPelicula,
                              NombrePelicula = peli.NombrePelicula,
                              Director = peli.Director,
                              AnoPelicula = peli.AnoPelicula
                          }).ToList();

            int i = 0;
            foreach (var p in pelicula)
            {
                PMPelicula spelicula = new PMPelicula();
                spelicula.idPelicula = pelicula.ElementAt(i).idPelicula;
                spelicula.NombrePelicula = pelicula.ElementAt(i).NombrePelicula;
                spelicula.Director = pelicula.ElementAt(i).Director;
                spelicula.AnoPelicula = pelicula.ElementAt(i).AnoPelicula;
                peliculas.Add(spelicula);
                i++;

            }
            return peliculas;
        }

    }
}
