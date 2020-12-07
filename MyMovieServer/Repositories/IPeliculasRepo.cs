using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;

namespace MyMovieServer.Repositories
{
    public interface IPeliculasRepo
    {
        Pelicula GetPeliMod(int id);
        void AgregarPelicula(Pelicula pelicula);
        void ModificarPelicula(Pelicula pelicula);
        public List<Pelicula> Recomendacion(int id);
        public List<Calificacion> GetCalificacionesByPelicula(int idPel);
        void AddComentario(Calificacion comentario);
    }
}