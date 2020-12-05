using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Linq;

namespace MyMovieServer.Logic
{
    public class LogicaModificacion
    {
        public int ModificarDatos(ModPeliculaPM mod, MyMovieDBContext context)
        {
            try
            {
                //Obtenemos la pelicula
                var pelicula = context.Pelicula.FirstOrDefault(item => item.IdPelicula == mod.id);

                if (pelicula != null)
                {
                    //Realizamos los cambios en la pelicula
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

                    //Guardamos los cambios en la base de datos
                    context.Update(pelicula);
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
