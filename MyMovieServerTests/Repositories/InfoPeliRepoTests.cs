using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using MyMovieServer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieServer.Repositories.Tests
{
    [TestClass()]
    public class InfoPeliRepoTests
    {
        Mock<IInfoPeliRepo> mock = new Mock<IInfoPeliRepo>();

        [TestMethod()]
        public void GetGenerosTest()
        { 
            var listadummy = new List<Genero>{ new Genero { IdGenero= 1, Genero1= "mockGenero1"},
                new Genero { IdGenero= 2, Genero1= "mockGenero2"}, new Genero { IdGenero= 3, Genero1= "mockGenero3"}};
            mock.Setup(info => info.GetGeneros()).Returns(listadummy);

            var mockObject = mock.Object;

            //Se espera obtener una lista de generos
            Assert.AreEqual(typeof(List<Genero>), mockObject.GetGeneros().GetType());

            //Se espera que la lista esté llena
            Assert.IsTrue(mockObject.GetGeneros().Count > 0);




        }

        [TestMethod()]
        public void GetIdiomasTest()
        {
            var listadummy = new List<Idioma>{ new Idioma { IdIdioma= 1, Idioma1= "mockIdioma1"},
                new Idioma { IdIdioma= 2, Idioma1= "mockIdioma2"}, new Idioma { IdIdioma= 3, Idioma1= "mockIdioma3"}};
            mock.Setup(info => info.GetIdiomas()).Returns(listadummy);

            var mockObject = mock.Object;

            //Se espera obtener una lista de Idiomas
            Assert.AreEqual(typeof(List<Idioma>), mockObject.GetIdiomas().GetType());

            //Se espera que la lista esté llena
            Assert.IsTrue(mockObject.GetIdiomas().Count > 0);
        }

        [TestMethod()]
        public void GetEstilosTest()
        {
            var listadummy = new List<Estilo>{ new Estilo { IdEstilo= 1, Estilo1= "mockEstilo1"},
                new Estilo { IdEstilo= 2, Estilo1= "mockEstilo2"}, new Estilo { IdEstilo= 3, Estilo1= "mockEstilo3"}};
            mock.Setup(info => info.GetEstilos()).Returns(listadummy);

            var mockObject = mock.Object;

            //Se espera obtener una lista de Estilos
            Assert.AreEqual(typeof(List<Estilo>), mockObject.GetEstilos().GetType());

            //Se espera que la lista esté llena
            Assert.IsTrue(mockObject.GetEstilos().Count > 0);
        }
    }
}