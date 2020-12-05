using MyMovieServer.Models;
using System.Collections.Generic;

namespace MyMovieServer.Repositories
{
    public interface IInfoPeliRepo
    {
        List<Estilo> GetEstilos();
        List<Genero> GetGeneros();
        List<Idioma> GetIdiomas();
    }
}