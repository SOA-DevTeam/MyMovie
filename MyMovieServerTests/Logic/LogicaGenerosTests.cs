using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieServer.Logic.Tests
{
    [TestClass()]
    public class LogicaGenerosTests
    {
        [TestMethod()]
        public void ObtenerGenerosTest()
        {
            var logicaGenero = new LogicaGeneros();
            var contexto = new MyMovieDBContext();
            var consulta = logicaGenero.ObtenerGeneros(contexto);

            //Al momento de realizar esta prueba se cuenta con  14 generos disponibles en la base de datos
            var cantidad = 0;
            foreach (GenerosPM gen in consulta)
            {
                cantidad += 1;
            }
            var testCant = cantidad == 14;

            //El primer elemento en la tabla debe ser el Genero Accion
            var primerElemento = (consulta.ElementAt(0).nombre == "Accion");

            //El genero en la posicion 12 de la lista tiene id 5 y corresponde a Supenso
            var suspenso = consulta.ElementAt(11).id == 5 && consulta.ElementAt(11).nombre == "Suspenso";

            Assert.IsTrue(testCant && primerElemento && suspenso);
        }
    }
}