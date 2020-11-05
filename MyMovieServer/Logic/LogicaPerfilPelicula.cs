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

        public PerfilPeliculaPM GetMovie(int id, MyMovieDBContext context)
        {
            PerfilPeliculaPM peliculas = new PerfilPeliculaPM();
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
                            where peli.IdPelicula==id
                            group joi by new { peli.IdPelicula, peli.NombrePelicula, 
                                peli.Director, peli.AnoPelicula, peli.Favorito, peli.NotaImdb, 
                                peli.NotaMetascore, gene.Genero1, idio.Idioma1, esti.Estilo1, peli.Imagen  } into gr
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
                                Promedio = gr.Average(x => x.Calificacion1)
                            }).ToList();


            
            PerfilPeliculaPM spelicula = new PerfilPeliculaPM();
            spelicula.idPelicula = pelicula.ElementAt(0).idPelicula;
            spelicula.NombrePelicula = pelicula.ElementAt(0).NombrePelicula;
            spelicula.Director = pelicula.ElementAt(0).Director;
            spelicula.AnoPelicula = pelicula.ElementAt(0).AnoPelicula;
            spelicula.Genero = pelicula.ElementAt(0).Genero;
            spelicula.Idioma = pelicula.ElementAt(0).Genero;
            spelicula.Imagen = pelicula.ElementAt(0).Imagen;
            spelicula.Estilo = pelicula.ElementAt(0).Estilo;
            spelicula.Favorito = (bool)pelicula.ElementAt(0).Favorito;
            spelicula.NotaIMDb = (decimal)pelicula.ElementAt(0).NotaIMDb;
            spelicula.NotaMetascore = (decimal)pelicula.ElementAt(0).NotaMetascore;
            spelicula.NotaComunidad = pelicula.ElementAt(0).Promedio;
            
            return spelicula;
        }
    }

}
