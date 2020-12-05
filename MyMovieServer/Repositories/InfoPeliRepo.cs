using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Repositories
{
    public class InfoPeliRepo : IInfoPeliRepo
    {
        private readonly MyMovieDBContext context;
        public InfoPeliRepo(MyMovieDBContext context)
        {
            this.context = context;
        }

        public List<Genero> GetGeneros()
        {
            return context.Genero.ToList();
        }

        public List<Idioma> GetIdiomas()
        {
            return context.Idioma.ToList();
        }

        public List<Estilo> GetEstilos()
        {
            return context.Estilo.ToList();
        }
    }
}
