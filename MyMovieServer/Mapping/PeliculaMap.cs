using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Mapping
{
    public class PeliculaMap : IPeliculaMap
    {
        public Pelicula NuevaPelicula(NuevaPeliculaPM p)
        {
            Pelicula nuevaPeli = new Pelicula()
            {
                NombrePelicula = p.nombre,
                Director = p.director,
                AnoPelicula = p.anno.ToString(),
                IdGenero = p.genero,
                IdIdioma = p.idioma,
                NotaImdb = p.mdb,
                NotaMetascore = p.meta,
                Favorito = p.fav,
                Imagen = p.imagen,
                IdEstilo = p.estilo,
                IndicePopularidad = p.pop
            };
            return nuevaPeli;
        }

        public Pelicula ModificarPelicula(Pelicula pelicula, ModPeliculaPM mod)
        {
            pelicula.NombrePelicula = mod.nombre;
            pelicula.Director = mod.director;
            pelicula.AnoPelicula = mod.anno.ToString();
            pelicula.IdGenero = mod.genero;
            pelicula.IdEstilo = mod.estilo;
            pelicula.IdIdioma = mod.idioma;
            pelicula.NotaImdb = mod.mdb;
            pelicula.NotaMetascore = mod.meta;
            pelicula.Favorito = mod.fav;
            pelicula.IndicePopularidad = mod.pop;
            pelicula.Imagen = mod.imagen;

            return pelicula;
        }

        public List<CalificacionesDePelicula> Recomendaciones(List<Pelicula> peliculas)
        {
            List<CalificacionesDePelicula> peliculasList = new List<CalificacionesDePelicula>();
            foreach (Pelicula pelicula in peliculas)
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
                peliculasList.Add(dummy);
            }
            return peliculasList;
        }


        public List<ComentariosPM> Comentarios(List<Calificacion> calificaciones)
        {
            List<ComentariosPM> comentarios = new List<ComentariosPM>();
            int i = 0;
            foreach (var c in calificaciones)
            {

                ComentariosPM comenta = new ComentariosPM();
                comenta.idCalificacion = calificaciones.ElementAt(i).IdCalificacion;
                comenta.Calificacion = (decimal)calificaciones.ElementAt(i).Calificacion1;
                comenta.Comentario = calificaciones.ElementAt(i).Comentario;
                comentarios.Insert(0, comenta);
                i++;

            }
            return comentarios;
        }

        //TENES QUE AGREGAR ACTUALIZAR INDICE DE POPULARIDAD
        public Calificacion AgregarComentario(ComentariosPM comentario)
        {
            Calificacion calificacion = new Calificacion
            {
                Comentario = comentario.Comentario,
                Calificacion1 = comentario.Calificacion,
                IdPelicula = comentario.idPelicula
            };
            return calificacion;
        }

        public Pelicula ActualizarIndicePop(Pelicula pelicula, PopularidadPM pop)
        {
            pelicula.IndicePopularidad += pop.indicePopularidad;
            return pelicula;
        }
    }
}
