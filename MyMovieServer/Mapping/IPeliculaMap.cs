using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;

namespace MyMovieServer.Mapping
{
    public interface IPeliculaMap
    {
        Pelicula NuevaPelicula(NuevaPeliculaPM p);
        Pelicula ModificarPelicula(Pelicula pelicula, ModPeliculaPM mod);
        List<CalificacionesDePelicula> Recomendaciones(List<Pelicula> peliculas);
        List<ComentariosPM> Comentarios(List<Calificacion> calificaciones);
        Calificacion AgregarComentario(ComentariosPM comentario);
        Pelicula ActualizarIndicePop(Pelicula pelicula, PopularidadPM pop);

    }
}