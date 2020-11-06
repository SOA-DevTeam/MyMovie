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
    public class LogicaIdiomasTests
    {
        [TestMethod()]
        public void ObtenerIdiomasTest()
        {
            var logicaIdioma = new LogicaIdiomas();
            var contexto = new MyMovieDBContext();
            var consulta = logicaIdioma.ObtenerIdiomas(contexto);

            //Al momento de realizar esta prueba se cuenta con  12 estilos disponibles en la base de datos
            var cantidad = 0;
            foreach (IdiomasPM idi in consulta)
            {
                cantidad += 1;
            }
            var testCant = cantidad == 12;

            //El primer elemento en la tabla debe ser el idioma Aleman
            var primerElemento = (consulta.ElementAt(0).nombre == "Aleman");
            //El genero en la posicion 8 de la lista tiene id 12 y corresponde a Neerlandes
            var doc = consulta.ElementAt(8).id == 12 && consulta.ElementAt(8).nombre == "Neerlandes";

            Assert.IsTrue(testCant && primerElemento && doc);
        }
    }
}