using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace MovieStoreApi.Worker
{
    public class MovieWorkerService : BackgroundService
    {
        private readonly IMovieWorker _movieWorker;
        public MovieWorkerService(IMovieWorker movieWorker)
        {
            _movieWorker = movieWorker;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _movieWorker.DoWork(cancellationToken:stoppingToken);
        }
    }
}
