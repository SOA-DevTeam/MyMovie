using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyMovieServer.Logic.Tests
{
    [TestClass()]
    public class LogicaAgregarComentarioTests
    {
        [TestMethod()]
        public void ComentarTest()
        {
            //Se instancia la clase de logica y el contexto
            var logicaComentario = new LogicaAgregarComentario();
            var context = new MyMovieDBContext();

            //Se crea un nuevo comentario para la pelicula de prueba
            var comentario = new ComentariosPM();
            comentario.idPelicula = 1511;
            comentario.Calificacion = 10;
            comentario.Comentario = "Comentario de prueba";

            //Se inserta el comentario en la base de datos y se retorna un 1 si es exitoso
            var respuesta = logicaComentario.Comentar(comentario, context);
            var exito = respuesta == 1;
            Assert.IsTrue(exito);
        }

        [TestMethod()]
        public void ActualizarPopularidadTest()
        {
            //Se instancia la clase de logica y el contexto
            var logicaComentario = new LogicaAgregarComentario();
            var context = new MyMovieDBContext();

            //Se crea un modelo de presentacion con la actualizacion de popularidad, en este caso
            //se elige 0 para que no modifique los datos
            var popularidad = new PopularidadPM();
            popularidad.idPelicula = 1511;
            popularidad.indicePopularidad = 0;

            //Se actualiza y si es exitoso se retorna un 1
            var respuesta = logicaComentario.ActualizarPopularidad(popularidad, context);
            var exito = respuesta == 1;
            Assert.IsTrue(exito);
        }
    }
}