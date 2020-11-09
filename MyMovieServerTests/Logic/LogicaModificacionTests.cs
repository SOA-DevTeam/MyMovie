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
    public class LogicaModificacionTests
    {
        [TestMethod()]
        public void ModificarDatosTest()
        {
            var LogicaMD = new LogicaModificacion();
            var contexto = new MyMovieDBContext();
            var getPelicula = new LogicaPerfilPelicula();
            var request = getPelicula.GetPelicula(1498, new MyMovieDBContext());
            //Obetenemos la pelicula a modificar
            var response = request.ElementAt(0);
            int i = 0;

            var peli = new ModPeliculaPM();
            peli.id = response.idPelicula;
            peli.nombre = response.NombrePelicula;
            peli.director = response.Director;
            peli.anno = 1998 + i;
            peli.genero = 5;
            peli.idioma = 1;
            peli.estilo = 4;
            peli.mdb = response.NotaIMDb;
            peli.meta = response.NotaMetascore;
            peli.imagen = response.Imagen;
            peli.pop = response.IndicePopularidad;
            peli.fav = response.Favorito;

            var consulta = (LogicaMD.ModificarDatos(peli, contexto)) == 1;


            //Test para modificar una pelicula, si se recibe datos nulos de la pelicula debe retornar 0
            var consultaFail = (LogicaMD.ModificarDatos(null, contexto)) == 0;

            i +=1;

            Assert.IsTrue(consultaFail && consulta);
        }
    }
}