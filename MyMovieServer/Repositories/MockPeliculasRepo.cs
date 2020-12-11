using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class MockPeliculasRepo : IPeliculasRepo
    {
        List<Calificacion> comentarios = new List<Calificacion>();
        List<Pelicula> peliculas = new List<Pelicula>();
        public int n;

        public MockPeliculasRepo()
        {
            Setup();
        }

        private void Setup()
        {
            Pelicula peli;
            for (int i=0; i<=4; i++)
            {
                peli = new Pelicula();
                peli.IdPelicula = i;
                peli.NombrePelicula = "Pelicula" + i;
                peli.Director = "Director";
                peli.AnoPelicula = "200" + i;
                peli.NotaImdb = 8;
                peli.NotaMetascore = 8;
                peli.IdIdioma = i;
                peli.IdGenero = i;
                peli.IdEstilo = i;
                peli.Favorito = false;
                peli.Imagen = "imagen" + i;
                peli.IndicePopularidad = 10;
                peliculas.Add(peli);
                Calificacion calificacion;
                for(int j=0; j<=4; j++)
                {
                    calificacion = new Calificacion();
                    calificacion.IdCalificacion = j;
                    calificacion.Calificacion1 = 1 + i + j;
                    calificacion.Comentario = "comentario" + j + " pelicula"+ i;
                    comentarios.Add(calificacion);
                }
                
            }
        }
        public int getSize()
        {
            return peliculas.Count;
        }
        public void AddComentario(Calificacion comentario)
        {
            comentarios.Add(comentario);
        }

        public void AgregarPelicula(Pelicula pelicula)
        {
            peliculas.Add(pelicula);
        }

        public List<Calificacion> GetCalificacionesByPelicula(int idPel)
        {
            return comentarios.FindAll(c => c.IdPelicula == idPel);
            
        }

        public Pelicula GetPeliMod(int id)
        {
            return peliculas.Find(p => p.IdPelicula == id);
        }

        public void ModificarPelicula(Pelicula pelicula)
        {
            var index = peliculas.FindIndex(p => p.IdPelicula == pelicula.IdPelicula);
            peliculas[index] = pelicula;
        }

        public List<Pelicula> Recomendacion(int id)
        {
            return peliculas.FindAll(p => p.IdGenero == id);
        }
    }
}
