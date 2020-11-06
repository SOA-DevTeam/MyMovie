using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class LogicaEstilos
    {
        public List<EstilosPM> ObtenerEstilos(MyMovieDBContext context)
        {
            List<EstilosPM> estiloList = new List<EstilosPM>();


            foreach (Estilo estilo in context.Estilo.ToList())
            {

                EstilosPM temp = new EstilosPM
                {
                    id = estilo.IdEstilo,
                    nombre = estilo.Estilo1
                };
                estiloList.Add(temp);
            }

            return estiloList;
        }
    }
}
