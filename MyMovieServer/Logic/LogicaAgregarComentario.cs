using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaAgregarComentario
    {
        public int Comentar(ComentariosPM c, MyMovieDBContext context)
        {
            try
            {
                Calificacion comentario = new Calificacion
                {
                    Comentario = c.Comentario,
                    Calificacion1 = c.Calificacion,
                    IdPelicula = c.idPelicula
                };
                context.Add(comentario);
                context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public int ActualizarPopularidad(PopularidadPM p, MyMovieDBContext context)
        {
            try
            {
                var pelicula = (from peli in context.Pelicula
                             where peli.IdPelicula == p.idPelicula
                             select peli).FirstOrDefault();
                pelicula.IndicePopularidad = pelicula.IndicePopularidad + p.indicePopularidad;
                context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }


    }
}
