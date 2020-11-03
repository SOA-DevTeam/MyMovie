using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaGeneros
    {

        public List<GenerosPM> ObtenerGeneros(MyMovieDBContext context)
        {
            List<GenerosPM> genList = new List<GenerosPM>();


            foreach (Genero gen in context.Genero.ToList())
            {

                GenerosPM temp = new GenerosPM
                {
                    id = gen.IdGenero,
                    nombre = gen.Genero1
                };
                genList.Add(temp);
            }

            return genList;
        }
    }
}
