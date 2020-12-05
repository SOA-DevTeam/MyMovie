using MyMovieServer.Models;

namespace MyMovieServer.Repositories
{
    public interface IPeliculasRepo
    {
        Pelicula GetPeliMod(int id);
        void AgregarPelicula(Pelicula pelicula);
        void ModificarPelicula(Pelicula pelicula);
    }
}