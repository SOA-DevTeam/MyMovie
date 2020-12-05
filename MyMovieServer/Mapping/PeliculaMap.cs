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
    }
}
