using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyMovieServer.Controllers;
using MyMovieServer.Mapping;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using MyMovieServer.Repositories;
using MyMovieServer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieServer.Controllers.Tests
{
    [TestClass()]
    public class PeliculasControllerTests
    {
        Mock<IPeliculaMap> mapper = new Mock<IPeliculaMap>();
        Mock<IPeliculasRepo> repository = new Mock<IPeliculasRepo>();
        Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();

        [TestMethod()]
        public void AddPeliculaTest()
        {
            IPeliculasRepo repo = new MockPeliculasRepo();

            var prueba = new PeliculasController(repo, unitOfWork.Object,mapper.Object);
            var pelicula = new NuevaPeliculaPM();
            pelicula.nombre = "Pelicula nueva";
            pelicula.director = "Director";
            pelicula.anno = 2000;
            pelicula.mdb = 8;
            pelicula.meta = 8;
            pelicula.fav = false;
            pelicula.idioma = 1;
            pelicula.genero = 1;
            pelicula.estilo = 1;
            pelicula.imagen = "imagen";
            pelicula.pop = 10;

            
            try { 
                prueba.AddPelicula(pelicula);
            }catch(Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        public void UpdatePeliculaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetComentariosTest()
        {
            Assert.Fail();
        }
    }
}