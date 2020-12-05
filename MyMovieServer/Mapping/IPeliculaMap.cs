using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;

namespace MyMovieServer.Mapping
{
    public interface IPeliculaMap
    {
        Pelicula NuevaPelicula(NuevaPeliculaPM p);
        Pelicula ModificarPelicula(Pelicula pelicula, ModPeliculaPM mod);
        
    }
}