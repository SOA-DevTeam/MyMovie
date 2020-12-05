using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Logic
{
    public class MovieRepository
    {
        private readonly MyMovieDBContext context;

        public MovieRepository(MyMovieDBContext context)
        {
            this.context = context;
        }

    }
}
