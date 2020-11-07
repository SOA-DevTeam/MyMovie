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
        public int Comentar(ComentariosPM c, int idPeli, MyMovieDBContext context)
        {
            try
            {
                Calificacion comentario = new Calificacion
                {
                    Comentario = c.Comentario,
                    Calificacion1 = c.Calificacion,
                    IdPelicula = idPeli
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


    }
}
