using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieServer.Logic;
using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieServer.Logic.Tests
{
    [TestClass()]
    public class LogicaPerfilPeliculaTests
    {
        [TestMethod()]
        public void GetPeliculaTest()
        {
            var getPelicula = new LogicaPerfilPelicula();
            var request = getPelicula.GetPelicula(1, new MyMovieDBContext());
            //Primer elemento de la respuesta
            var response = request.ElementAt(0);

            //Al existir solo un elemento con ese nombre en la base de datos, se comprueba que sea una lista de un elemento
            //Tambien se comprueba que la mayoria de los datos son los mismos del elemento en la base de datos
            var isEqual = request.Count == 1 && response.idPelicula == 1 && response.NombrePelicula.Equals("Movie 2")
                && response.Director.Equals("Director 2") && response.AnoPelicula.Equals("2000") 
                && response.Genero.Equals("Infantil") && response.Idioma.Equals("Ingles") && response.Estilo.Equals("Animacion") && response.Favorito == false ;

            //Si el elemento es igual, se pasa la prueba
            Assert.IsTrue(isEqual);
        }

        [TestMethod()]
        public void GetComentariosTest()
        {
            var getPelicula = new LogicaPerfilPelicula();
            var request = getPelicula.GetComentarios(1, new MyMovieDBContext());
            //Primer elemento de la respuesta
            var response = request.ElementAt(0);

            //Se comprueba que el primer elemento de la lista sea el que tiene el id=1 y por lo tanto sus respectivos
            //datos
            var isEqual = response.idCalificacion==1 && response.Calificacion==10 && response.Comentario.Equals("Very good movie");

            //Si el elemento es igual al esperado, se pasa la prueba
            Assert.IsTrue(isEqual);
        }
    }
}