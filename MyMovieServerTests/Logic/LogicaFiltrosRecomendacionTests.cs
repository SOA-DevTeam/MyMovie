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
            //Ejecuta la función notacomunidad y evalúa que el valor de esta sea 5.6666666667
            var test = controller.notacomunidad(1, context) == 5.6666666666666666666666666667m;
            //Ejecuta la función para obtener todos los generos y compara el primer valor con Accion
            var test2 = controller.getGen(context)[0].Genero1 == "Accion";
            //Ejecuta la función para obtener todas las peliculas de un genero y compara el idGenero de la primer pelicula con 1
            var test3 = controller.getPeliculas(context, 1)[0].IdGenero == 1;

            Assert.IsTrue(test && test2 && test3);
        }
    }
}
