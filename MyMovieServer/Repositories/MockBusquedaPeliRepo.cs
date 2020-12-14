using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class MockBusquedaPeliRepo : IBusquedaPeliRepo
    {
        List<PeliculaGeneralPM> peliculasBusqueda = new List<PeliculaGeneralPM>();
        List<PerfilPeliculaPM> peliculaPerfil = new List<PerfilPeliculaPM>();

        public MockBusquedaPeliRepo()
        {
            Setup();
        }

        private void Setup()
        {
            for(int i = 1; i<=5; i++)
            {
                var pb = new PeliculaGeneralPM();
                var pp = new PerfilPeliculaPM();
                pb.idPelicula = i;
                pp.idPelicula = i;
                pb.NombrePelicula = "Pelicula" + i;
                pp.NombrePelicula = "Pelicula" + i;
                pb.AnoPelicula = "200" + i;
                pp.AnoPelicula = "200" + i;
                pb.Director = "Director" + i;
                pp.Director = "Director" + i;
                pb.NotaComunidad = 5 + i;
                pp.NotaComunidad = 5 + i;
                pp.Idioma = new Idioma { IdIdioma = 1, Idioma1 ="Idioma"};
                pp.Genero = new Genero { IdGenero = 1, Genero1 = "Genero"};
                pp.Estilo = new Estilo { IdEstilo = 1, Estilo1 = "Estilo"};
                pp.Favorito = false;
                pp.Imagen = "Imagen";
                pp.IndicePopularidad = 10 + 5 * i; 
            }
        }

        public List<PeliculaGeneralPM> Busqueda(string name)
        {
            return peliculasBusqueda.FindAll(p => p.NombrePelicula.Contains(name));
        }

        public List<PerfilPeliculaPM> PerfilPelicula(int id)
        {
            return peliculaPerfil.FindAll(p => p.idPelicula == id) ;
        }
    }
}
