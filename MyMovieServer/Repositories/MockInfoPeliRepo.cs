using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class MockInfoPeliRepo : IInfoPeliRepo
    {
        List<Genero> generos = new List<Genero>();
        List<Estilo> estilos = new List<Estilo>();
        List<Idioma> idiomas = new List<Idioma>();

        public MockInfoPeliRepo()
        {
            Setup();
        }

        private void Setup()
        {
            Genero genero;
            Estilo estilo;
            Idioma idioma;
            for(int i = 0; i<=5; i++)
            {
                genero = new Genero();
                estilo = new Estilo();
                idioma = new Idioma();
                genero.IdGenero = i;
                estilo.IdEstilo = i;
                idioma.IdIdioma = i;
                genero.Genero1 = "MockGenero" + i;
                estilo.Estilo1 = "MockEstilo" + i;
                idioma.Idioma1 = "MockIdioma" + i;
                generos.Add(genero);
                estilos.Add(estilo);
                idiomas.Add(idioma);

            }
        }

        public List<Estilo> GetEstilos()
        {
            return estilos;
        }

        public List<Genero> GetGeneros()
        {
            return generos;
        }

        public List<Idioma> GetIdiomas()
        {
            return idiomas;
        }
    }
}
