using MyMovieServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyMovieDBContext context;
        public UnitOfWork(MyMovieDBContext context)
        {
            this.context = context;

        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
