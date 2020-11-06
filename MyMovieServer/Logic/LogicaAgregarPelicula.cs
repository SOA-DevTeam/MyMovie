using Microsoft.EntityFrameworkCore;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaAgregarPelicula
    {
        public int AgregarPelicula(NuevaPeliculaPM p, MyMovieDBContext context)
        {
            try
            {
                Pelicula peli = new Pelicula
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
                context.Add(peli);
                context.SaveChanges();
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
