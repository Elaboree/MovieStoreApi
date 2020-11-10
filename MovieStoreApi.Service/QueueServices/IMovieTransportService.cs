using MovieStoreApi.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.QueueServices
{
    public interface IMovieTransportService
    {
        Task InsertMovies(List<MovieTransformModel> movieTransformModelList);
    }
}
