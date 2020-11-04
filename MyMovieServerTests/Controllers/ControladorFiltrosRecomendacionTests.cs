using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Controllers;
using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieServer.Controllers.Tests
{
    [TestClass()]
    public class ControladorFiltrosRecomendacionTests
    {
        [TestMethod()]
        public void GetTest1()
        {
            MyMovieDBContext context  = new MyMovieDBContext();
            RecommendationFilterController controller = new RecommendationFilterController(context);
            Console.WriteLine(controller.GetGen()[0].Genero1);
            Console.WriteLine(controller.GetPeliculas(2, 20, 20, 20, 20)[0].NombrePelicula);

        }
    }
}