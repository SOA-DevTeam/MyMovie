using Microsoft.AspNetCore.Mvc;
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
        

        [TestMethod()]
        public void AddPeliculaTest()
        {
            var mapper = new Mock<IPeliculaMap>();
            var repository = new Mock<IPeliculasRepo>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IPeliculasRepo repo = new MockPeliculasRepo();

            var prueba = new PeliculasController(repo, unitOfWork.Object, mapper.Object);
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


            try
            {
                prueba.AddPelicula(pelicula);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void UpdatePeliculaTest()
        {
            var mapper = new Mock<PeliculaMap>();
            var repository = new Mock<IPeliculasRepo>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IPeliculasRepo repo = new MockPeliculasRepo();

            var peli = new ModPeliculaPM
            {
                id = 1,
                nombre = "nombre modificado",
                director = "director",
                anno = 2000,
                genero = 1,
                estilo = 1,
                idioma = 1,
                mdb = 10,
                meta = 10,
                fav = true,
                pop = 20,
                imagen = "imagen",
            };

            var prueba = new PeliculasController(repo, unitOfWork.Object, mapper.Object);

            prueba.UpdatePelicula(peli);
            
        }

        [TestMethod()]
        public void GetComentariosTest()
        {
            var mapper = new Mock<IPeliculaMap>();
            var repository = new Mock<IPeliculasRepo>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IPeliculasRepo repo = new MockPeliculasRepo();

            var prueba = new PeliculasController(repo, unitOfWork.Object, mapper.Object);
            var comentarios = prueba.GetComentarios(1);
            Assert.IsInstanceOfType(comentarios, typeof(ObjectResult));
            var response = comentarios as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);


        }

        [TestMethod()]
        public void ActualizarPopularidadTest()
        {
            var mapper = new Mock<PeliculaMap>();
            var repository = new Mock<IPeliculasRepo>();
            var unitOfWork = new Mock<IUnitOfWork>();
            PopularidadPM pop = new PopularidadPM
            {
                idPelicula = 1,
                indicePopularidad = 15
            };
            IPeliculasRepo repo = new MockPeliculasRepo();
            var prueba = new PeliculasController(repo, unitOfWork.Object, mapper.Object);
            try
            {
                prueba.ActualizarPopularidad(pop);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void GetPeliculaByRecTest()
        {
            var mapper = new Mock<PeliculaMap>();
            var repository = new Mock<IPeliculasRepo>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IPeliculasRepo repo = new MockPeliculasRepo();

            var prueba = new PeliculasController(repo, unitOfWork.Object, mapper.Object);
            var resul = prueba.GetPeliculaByRec(1, 20, 20, 20, 20, 20);
            Assert.IsInstanceOfType(resul, typeof(ObjectResult));
            var response = resul as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

        }
    }
}