using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieServer.Logic.Tests
{
    [TestClass()]
    public class LogicaFiltrosRecomendacionTests
    {
        [TestMethod()]
        public void notacomunidadTest()
        {
            MyMovieDBContext context = new MyMovieDBContext();
            LogicaFiltrosRecomendacion controller = new LogicaFiltrosRecomendacion();
            var test = controller.notacomunidad(1, context) == 5.6666666666666666666666666667m;
            var test2 = controller.getGen(context)[0].Genero1 == "Accion";
            var test3 = controller.getPeliculas(context, 1)[0].IdGenero == 1;

            Assert.IsTrue(test && test2 && test3);
        }
    }
}