using System.Threading.Tasks;

namespace MyMovieServer.UoW
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}