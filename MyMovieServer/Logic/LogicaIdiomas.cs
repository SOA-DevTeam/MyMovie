using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaIdiomas
    {
        public List<IdiomasPM> ObtenerIdiomas(MyMovieDBContext context)
        {
            List<IdiomasPM> idiomaList = new List<IdiomasPM>();


            foreach (Idioma idioma in context.Idioma.ToList())
            {

                IdiomasPM temp = new IdiomasPM
                {
                    id = idioma.IdIdioma,
                    nombre = idioma.Idioma1
                };
                idiomaList.Add(temp);
            }

            return idiomaList;
        }
    }
}
