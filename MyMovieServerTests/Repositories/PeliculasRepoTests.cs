using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyMovieServer.Models;
using MyMovieServer.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MyMovieServer.Repositories.Tests
{
    [TestClass()]
    public class PeliculasRepoTests
    {
        Mock<IPeliculasRepo> mock = new Mock<IPeliculasRepo>();

        [TestMethod()]
        public void GetPeliModTest()
        {
            //Se espera que se retorne una pelicula con el id indicado
            mock.Setup(pr => pr.GetPeliMod(It.IsAny<int>())).Returns((int id) =>
            {
                return new Pelicula
                {
                    IdPelicula = id,
                    NombrePelicula = "pelicula" + id.ToString(),
                    AnoPelicula = "2015",
                    Director = "director",
                    Favorito = true,
                    IdEstilo = 1,
                    IdGenero = 1,
                    IdIdioma = 1,
                    Imagen = "imagen",
                    NotaImdb = (decimal?)8.7,
                    NotaMetascore = (decimal?)8.7,
                    IndicePopularidad = 10
                };
            });

            var mockObject = mock.Object;
            //Dependiendo del id ingresado se retorna un objeto Pelicula con dicho id
            bool idEqual = mockObject.GetPeliMod(1).IdPelicula == 1 && mockObject.GetPeliMod(2).IdPelicula == 2;
            Assert.IsTrue(idEqual);

        }

        [TestMethod()]
        public void RecomendacionTest()
        {
            mock.Setup(pr => pr.Recomendacion(It.IsAny<int>())).Returns((int idg) =>
            {
                return new List<Pelicula> { new Pelicula { IdPelicula = 1,
                NombrePelicula = "peliculagenero" + idg.ToString(),
                AnoPelicula = "2015",
                Director = "director1",
                Favorito = true,
                IdEstilo = 1,
                IdGenero = idg,
                IdIdioma = 1,
                Imagen = "imagen",
                NotaImdb = (decimal?)8.7,
                NotaMetascore = (decimal?)8.7,
                IndicePopularidad = 10 },
                new Pelicula { IdPelicula = 12,
                    NombrePelicula = "peliculagenero" + idg.ToString(),
                    AnoPelicula = "2012",
                    Director = "director2",
                    Favorito = true,
                    IdEstilo = 1,
                    IdGenero = idg,
                    IdIdioma = 1,
                    Imagen = "imagen",
                    NotaImdb = (decimal?)8.7,
                    NotaMetascore = (decimal?)8.7,
                    IndicePopularidad = 10
                }
            };
            });

            mock.Setup(pr => pr.Recomendacion(10)).Returns(new List<Pelicula>());

           var mockObject = mock.Object;
            //Los elementos de la lista deben de tener idGenero igual al ingresado
            bool allIdsEqual = mockObject.Recomendacion(1).ElementAt(0).IdGenero == 1 &&
            mockObject.Recomendacion(1).ElementAt(1).IdGenero == 1 &&
            mockObject.Recomendacion(2).ElementAt(0).IdGenero == 2 &&
            mockObject.Recomendacion(2).ElementAt(1).IdGenero == 2;
            //Los elementos de la lista se deben de presentar en orden del idPelicula
            bool inOrder = mockObject.Recomendacion(1).ElementAt(0).IdPelicula < mockObject.Recomendacion(1).ElementAt(1).IdPelicula;
            //Si no existen peliculas del genero se debe retornar una lista vacía
            bool emptyIfNotId = mockObject.Recomendacion(10).Count == 0;

            Assert.IsTrue(allIdsEqual && inOrder && emptyIfNotId);
        }

        [TestMethod()]
        public void GetCalificacionesByPeliculaTest()
        {
            //Se genera una lista de las calificaciones que se le hayan dado a la película con determinado id
            mock.Setup(pr => pr.GetCalificacionesByPelicula(It.IsAny<int>())).Returns((int id) => {
                return new List<Calificacion>
            { new Calificacion { 
                IdPelicula = id,
                IdCalificacion = 1, 
                Calificacion1 = 10, 
                Comentario = "comentario"},
                new Calificacion {
                IdPelicula = id,
                IdCalificacion = 3,
                Calificacion1 = 8,
                Comentario = "comentario"},
                new Calificacion {
                IdPelicula = id,
                IdCalificacion = 5,
                Calificacion1 = 9,
                Comentario = ""}
                };
            });

            //Si la pelicula id 10 no tiene comentarios retorna una lista vacía
            mock.Setup(pr => pr.GetCalificacionesByPelicula(10)).Returns(new List<Calificacion>());

            var mockObject = mock.Object;
            //Se espera que todas las calificaciones sean de la pelicula con el id ingresado
            bool allIdsEqual = 1 == mockObject.GetCalificacionesByPelicula(1).ElementAt(0).IdPelicula &&
            1 == mockObject.GetCalificacionesByPelicula(1).ElementAt(1).IdPelicula &&
            1 == mockObject.GetCalificacionesByPelicula(1).ElementAt(2).IdPelicula;
            //Se espera que se retornen objetos de calificacion con sus campos
            bool allFields = mockObject.GetCalificacionesByPelicula(1).ElementAt(0).Comentario.Length >=0 &&
            mockObject.GetCalificacionesByPelicula(1).ElementAt(0).IdCalificacion > 0 && 
            mockObject.GetCalificacionesByPelicula(1).ElementAt(0).Calificacion1 >= 0;
            //Se espera que los elementos estén en orden de id
            bool inOrder = mockObject.GetCalificacionesByPelicula(1).ElementAt(0).IdCalificacion <
            mockObject.GetCalificacionesByPelicula(1).ElementAt(1).IdCalificacion;
            //Se espera que si no se ha calificado la pelicula, se retorne una lista vacía
            bool emptyIfNotId = mockObject.GetCalificacionesByPelicula(10).Count == 0;


            Assert.IsTrue(allIdsEqual && allFields && inOrder && emptyIfNotId);

        }
    }
}