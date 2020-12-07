using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System.Collections.Generic;

namespace MyMovieServer.Mapping
{
    public interface IKeyValueMap
    {
        List<KeyValuePM> EstilosMap(List<Estilo> estilos);
        List<KeyValuePM> GenerosMap(List<Genero> generos);
        List<KeyValuePM> IdiomasMap(List<Idioma> idiomas);
    }
}