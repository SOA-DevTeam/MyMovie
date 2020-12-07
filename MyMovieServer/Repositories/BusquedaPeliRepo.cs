using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class BusquedaPeliRepo : IBusquedaPeliRepo
    {
        private readonly MyMovieDBContext context;

        public BusquedaPeliRepo(MyMovieDBContext context)
        {
            this.context = context;
        }

        public List<PeliculaGeneralPM> Busqueda(string name)
        {
            List<PeliculaGeneralPM> peliculas = new List<PeliculaGeneralPM>();
            var pelicula = (from peli in context.Pelicula
                            join cali in context.Calificacion
                            on peli.IdPelicula equals cali.IdPelicula into joined
                            from joi in joined.DefaultIfEmpty()
                            where peli.NombrePelicula.Contains(name)
                            group joi by new { peli.IdPelicula, peli.NombrePelicula, peli.Director, peli.AnoPelicula } into gr
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
                PeliculaGeneralPM spelicula = new PeliculaGeneralPM();
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

        public List<PerfilPeliculaPM> PerfilPelicula(int id)
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
                                gene.IdGenero,
                                idio.Idioma1,
                                idio.IdIdioma,
                                esti.Estilo1,
                                esti.IdEstilo,
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
                                Promedio = gr.Average(x => x.Calificacion1),
                                IdGenero = gr.Key.IdGenero,
                                IdIdioma = gr.Key.IdIdioma,
                                IdEstilo = gr.Key.IdEstilo
                            }).ToList();


            int i = 0;
            foreach (var p in pelicula)
            {

                PerfilPeliculaPM spelicula = new PerfilPeliculaPM();
                spelicula.idPelicula = pelicula.ElementAt(i).idPelicula;
                spelicula.NombrePelicula = pelicula.ElementAt(i).NombrePelicula;
                spelicula.Director = pelicula.ElementAt(i).Director;
                spelicula.AnoPelicula = pelicula.ElementAt(i).AnoPelicula;
                spelicula.Genero = new Genero();
                spelicula.Genero.Genero1 = pelicula.ElementAt(i).Genero;
                spelicula.Genero.IdGenero = pelicula.ElementAt(i).IdGenero;
                spelicula.Idioma = new Idioma();
                spelicula.Idioma.IdIdioma = pelicula.ElementAt(i).IdIdioma;
                spelicula.Idioma.Idioma1 = pelicula.ElementAt(i).Idioma;
                spelicula.Imagen = pelicula.ElementAt(i).Imagen;
                spelicula.Estilo = new Estilo();
                spelicula.Estilo.IdEstilo = pelicula.ElementAt(i).IdEstilo;
                spelicula.Estilo.Estilo1 = pelicula.ElementAt(i).Estilo;
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
    }
}
