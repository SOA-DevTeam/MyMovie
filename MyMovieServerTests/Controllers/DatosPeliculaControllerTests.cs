using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyMovieServer.Controllers;
using MyMovieServer.Mapping;
using MyMovieServer.Repositories;
using MyMovieServer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieServer.Controllers.Tests
{
    [TestClass()]
    public class DatosPeliculaControllerTests
    {
        [TestMethod()]
        public void GetPeliculasByNameTest()
        {
            var repository = new Mock<IPeliculasRepo>();
            IBusquedaPeliRepo repo = new MockBusquedaPeliRepo();

            var prueba = new DatosPeliculaController(repo);
            var resul = prueba.GetPeliculasByName("Pelicula");
            Assert.IsInstanceOfType(resul, typeof(ObjectResult));
            var response = resul as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod()]
        public void GetPeliculaTest()
        {
            var repository = new Mock<IPeliculasRepo>();
            IBusquedaPeliRepo repo = new MockBusquedaPeliRepo();

            var prueba = new DatosPeliculaController(repo);
            var resul = prueba.GetPelicula(1);
            Assert.IsInstanceOfType(resul, typeof(ObjectResult));
            var response = resul as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }
    }
}