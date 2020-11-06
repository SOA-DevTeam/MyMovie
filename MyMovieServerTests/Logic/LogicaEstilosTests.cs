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
    public class LogicaEstilosTests
    {
        [TestMethod()]
        public void ObtenerEstilosTest()
        {
            var logicaEstilo = new LogicaEstilos();
            var contexto = new MyMovieDBContext();
            var consulta = logicaEstilo.ObtenerEstilos(contexto);

            //Al momento de realizar esta prueba se cuenta con  11 estilos disponibles en la base de datos
            var cantidad = 0;
            foreach (EstilosPM gen in consulta)
            {
                cantidad += 1;
            }
            var testCant = cantidad == 12;

            //El primer elemento en la tabla debe ser el Estilo Animacion
            var primerElemento = (consulta.ElementAt(0).nombre == "Animacion");
            //El genero en la posicion 7 de la lista tiene id 5 y corresponde a Documental
            var doc = consulta.ElementAt(6).id == 5 && consulta.ElementAt(6).nombre == "Documental";

            Assert.IsTrue(testCant && primerElemento && doc);
        }
    }
}