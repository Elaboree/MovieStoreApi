using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Data.Context;
using MovieStoreApi.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.Data.Repository.v1
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieStoreContext context) : base(context)
        {

        }
        private MovieStoreContext MovieStoretContext
        {
            get { return Context as MovieStoreContext; }
        }

        public async Task<List<Movie>> GetMoviesByPageSizeAsync(int pageIndex, int pageSize)
        {
            return await MovieStoretContext.Movies.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Movie> GetMoviesWithUserCritic(int movieId, int userId)
        {
            return await MovieStoretContext.Movies
             .Where(m => m.Id == movieId)
             .Include(m => m.Critics)
             .Where(a => a.Critics.Any(c => c.UserId == userId))
             .FirstOrDefaultAsync();
        }
    }
}
