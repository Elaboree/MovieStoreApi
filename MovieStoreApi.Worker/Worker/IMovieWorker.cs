using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Worker
{
    public interface IMovieWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}