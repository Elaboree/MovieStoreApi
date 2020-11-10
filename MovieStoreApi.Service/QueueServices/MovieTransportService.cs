using MediatR;
using MovieStoreApi.Service.Models;
using MovieStoreApi.Service.v1.Command;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.QueueServices
{
    public class MovieTransportService : IMovieTransportService
    {
        private readonly IMediator _mediator;
        public MovieTransportService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task InsertMovies(List<MovieTransformModel> movieTransformModelList)
        {
            AddMovieByQueueCommand command = new AddMovieByQueueCommand { Movies = movieTransformModelList };
            await _mediator.Send(command);
        }
    }
}
