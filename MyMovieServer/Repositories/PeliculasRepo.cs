using MyMovieServer.Logic;
using MyMovieServer.Mapping;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class PeliculasRepo : IPeliculasRepo
    {
        private readonly MyMovieDBContext context;

        public PeliculasRepo(MyMovieDBContext context)
        {
            this.context = context;
        }

        public Pelicula GetPeliMod(int id)
        {
            return context.Pelicula.FirstOrDefault(item => item.IdPelicula == id);
        }

        public void AgregarPelicula(Pelicula pelicula)
        {
            context.Add(pelicula);
        }

        public void ModificarPelicula(Pelicula pelicula)
        {
            context.Update(pelicula);
        }

        public List<Pelicula> Recomendacion(int id)
        {
            return context.Pelicula.Where(p=>p.IdGenero==id).ToList();
        }

        public List<Calificacion> GetCalificacionesByPelicula(int idPel)
        {
            return context.Calificacion.Where(c => c.IdPelicula == idPel).ToList();
        }

        public void AddComentario(Calificacion comentario) 
        {
            context.Add(comentario);
        }

    }
}
