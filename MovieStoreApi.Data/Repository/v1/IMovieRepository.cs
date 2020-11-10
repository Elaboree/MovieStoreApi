using MovieStoreApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreApi.Data.Repository.v1
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetMoviesByPageSizeAsync(int pageIndex,int pageSize);

        Task<Movie> GetMoviesWithUserCritic(int movieId,int userId);
    }
}
