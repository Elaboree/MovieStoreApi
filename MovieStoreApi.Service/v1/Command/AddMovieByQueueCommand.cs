using MediatR;
using MovieStoreApi.Service.Models;
using System.Collections.Generic;

namespace MovieStoreApi.Service.v1.Command
{
    public class AddMovieByQueueCommand : IRequest<Unit>
    {
        public List<MovieTransformModel> Movies { get; set; }
    }
}
