
using MovieStoreApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreApi.Data.Repository.v1
{
    public interface ICriticRepository : IRepository<Critic>
    {
        Task<List<Critic>> GetUserCriticsAsync(int userId, int movieId);
    }
}
