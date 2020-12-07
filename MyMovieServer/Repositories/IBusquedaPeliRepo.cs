using MyMovieServer.Presentation_Model;
using System.Collections.Generic;

namespace MyMovieServer.Repositories
{
    public interface IBusquedaPeliRepo
    {
        List<PeliculaGeneralPM> Busqueda(string name);
        List<PerfilPeliculaPM> PerfilPelicula(int id);
    }
}