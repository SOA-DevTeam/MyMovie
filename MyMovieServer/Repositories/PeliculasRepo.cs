using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class PeliculasRepo : IPeliculasRepo
    {
        private readonly MyMovieDBContext context;

        public PeliculasRepo(MyMovieDBContext context)
        {
            this.context = context;
        }

        public  Pelicula GetPeliMod(int id)
        {
           return context.Pelicula.FirstOrDefault(item => item.IdPelicula == id);
        } 

        public void AgregarPelicula(Pelicula pelicula)
        {
            context.Add(pelicula);
        }

        public void ModificarPelicula(Pelicula pelicula)
        {
            context.Update(pelicula);
        }

    }
}
