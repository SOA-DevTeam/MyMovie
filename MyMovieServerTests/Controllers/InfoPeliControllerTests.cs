using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MyMovieServer.Mapping;
using MyMovieServer.Repositories;
using MyMovieServer.UoW;
using MyMovieServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyMovieServer.Controllers.Tests
{
    [TestClass()]
    public class InfoPeliControllerTests
    {
        Mock<IKeyValueMap> mapper = new Mock<IKeyValueMap>();
        Mock<IInfoPeliRepo> repository = new Mock<IInfoPeliRepo>();
        Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();

        [TestMethod()]
        public void GetGPMTest()
        {
            IInfoPeliRepo repo = new MockInfoPeliRepo();

            var prueba = new InfoPeliController(repo, mapper.Object);
            var generos = prueba.GetGPM();
            Assert.IsInstanceOfType(generos, typeof(ObjectResult));
            var response = generos as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

        }

        [TestMethod()]
        public void GetIPMTest()
        {
            IInfoPeliRepo repo = new MockInfoPeliRepo();

            var prueba = new InfoPeliController(repo, mapper.Object);
            var idiomas = prueba.GetIPM();
            Assert.IsInstanceOfType(idiomas, typeof(ObjectResult));
            var response = idiomas as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod()]
        public void GetEPMTest()
        {
            IInfoPeliRepo repo = new MockInfoPeliRepo();

            var prueba = new InfoPeliController(repo, mapper.Object);
            var estilos = prueba.GetEPM();
            Assert.IsInstanceOfType(estilos, typeof(ObjectResult));
            var response = estilos as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }
    }
}