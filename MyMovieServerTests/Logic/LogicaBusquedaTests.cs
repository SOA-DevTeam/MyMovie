﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Logic;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMovieServer.Models;

namespace MyMovieServer.Logic.Tests
{
    [TestClass()]
    public class LogicaBusquedaTests
    {
        [TestMethod()]
        public void GetPeliculasTest()
        {
            
            var getMovies = new LogicaBusqueda();
            var request = getMovies.GetPeliculas("The TEST Movie", new MyMovieDBContext());
            //Primer elemento de la respuesta
            var response = request.ElementAt(0);

            //Al existir solo un elemento con ese nombre en la base de datos, se comprueba que sea una lista de un elemento
            //Tambien se comprueba que los datos son los mismos del elemento en la base de datos
            var isEqual = request.Count == 2 && response.idPelicula == 1493 && response.NombrePelicula.Equals("The TEST Movie")
                && response.Director.Equals("Mark Tester") && response.AnoPelicula.Equals("2020");

            //Si el elemento es igual, se pasa la prueba
            Assert.IsTrue(isEqual);
        }
    }
}