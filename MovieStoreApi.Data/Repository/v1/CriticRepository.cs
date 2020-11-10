using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Data.Context;
using MovieStoreApi.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.Data.Repository.v1
{
    public class CriticRepository : Repository<Critic>, ICriticRepository
    {
        public CriticRepository(MovieStoreContext context) : base(context)
        {

        }
        private MovieStoreContext MovieStoretContext
        {
            get { return Context as MovieStoreContext; }
        }
        public async Task<List<Critic>> GetUserCriticsAsync(int userId, int movieId)
        {
            return await MovieStoretContext.Critics
             .Include(m => m.Movie)
             .Where(m => m.Id == movieId && m.UserId == userId)
             .ToListAsync();
        }
    }
}
