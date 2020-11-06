using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaPerfilPelicula
    {

        public List<PerfilPeliculaPM> GetPelicula(int id, MyMovieDBContext context)
        {
            List<PerfilPeliculaPM> peliculas = new List<PerfilPeliculaPM>();
            var pelicula = (from peli in context.Pelicula
                            join gene in context.Genero
                            on peli.IdGenero equals gene.IdGenero
                            join esti in context.Estilo
                            on peli.IdEstilo equals esti.IdEstilo
                            join idio in context.Idioma
                            on peli.IdIdioma equals idio.IdIdioma
                            join cali in context.Calificacion
                            on peli.IdPelicula equals cali.IdPelicula into joined
                            from joi in joined.DefaultIfEmpty()
                            where peli.IdPelicula == id
                            group joi by new
                            {
                                peli.IdPelicula,
                                peli.NombrePelicula,
                                peli.Director,
                                peli.AnoPelicula,
                                peli.Favorito,
                                peli.NotaImdb,
                                peli.NotaMetascore,
                                gene.Genero1,
                                idio.Idioma1,
                                esti.Estilo1,
                                peli.Imagen,
                                peli.IndicePopularidad
                            } into gr
                            select new
                            {
                                idPelicula = gr.Key.IdPelicula,
                                NombrePelicula = gr.Key.NombrePelicula,
                                Director = gr.Key.Director,
                                AnoPelicula = gr.Key.AnoPelicula,
                                Genero = gr.Key.Genero1,
                                Idioma = gr.Key.Idioma1,
                                Imagen = gr.Key.Imagen,
                                Estilo = gr.Key.Estilo1,
                                Favorito = gr.Key.Favorito,
                                NotaIMDb = gr.Key.NotaImdb,
                                NotaMetascore = gr.Key.NotaMetascore,
                                IndicePopularidad = gr.Key.IndicePopularidad,
                                Promedio = gr.Average(x => x.Calificacion1)
                            }).ToList();


            int i = 0;
            foreach (var p in pelicula)
            {

                PerfilPeliculaPM spelicula = new PerfilPeliculaPM();
                spelicula.idPelicula = pelicula.ElementAt(i).idPelicula;
                spelicula.NombrePelicula = pelicula.ElementAt(i).NombrePelicula;
                spelicula.Director = pelicula.ElementAt(i).Director;
                spelicula.AnoPelicula = pelicula.ElementAt(i).AnoPelicula;
                spelicula.Genero = pelicula.ElementAt(i).Genero;
                spelicula.Idioma = pelicula.ElementAt(i).Idioma;
                spelicula.Imagen = pelicula.ElementAt(i).Imagen;
                spelicula.Estilo = pelicula.ElementAt(i).Estilo;
                spelicula.Favorito = (bool)pelicula.ElementAt(i).Favorito;
                spelicula.NotaIMDb = (decimal)pelicula.ElementAt(i).NotaIMDb;
                spelicula.NotaMetascore = (decimal)pelicula.ElementAt(i).NotaMetascore;
                spelicula.NotaComunidad = pelicula.ElementAt(i).Promedio;
                spelicula.IndicePopularidad = (decimal)pelicula.ElementAt(i).IndicePopularidad;
                peliculas.Add(spelicula);
                i++;

            }
            return peliculas;
        }

        public List<ComentariosPM> GetComentarios(int id, MyMovieDBContext context)
        {
            List<ComentariosPM> comentarios = new List<ComentariosPM>();
            var comentario = (from coment in context.Calificacion
                              where coment.IdPelicula == id
                              orderby coment.IdPelicula
                              select new
                              {
                                  idCalificacion = coment.IdCalificacion,
                                  Calificacion = coment.Calificacion1,
                                  Comentario = coment.Comentario
                              }).ToList();
            int i = 0;
            foreach (var c in comentario)
            {

                ComentariosPM comenta = new ComentariosPM();
                comenta.idCalificacion = comentario.ElementAt(i).idCalificacion;
                comenta.Calificacion = (decimal)comentario.ElementAt(i).Calificacion;
                comenta.Comentario = comentario.ElementAt(i).Comentario;
                comentarios.Add(comenta);
                i++;

            }
            return comentarios;
        }

    }
}
