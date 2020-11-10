using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreApi.Data.Repository.v1;
using MovieStoreApi.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.v1.Command
{
    public class AddMovieByQueueCommandHandler : IRequestHandler<AddMovieByQueueCommand>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IMapper _mapper;
        public AddMovieByQueueCommandHandler(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _serviceScopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddMovieByQueueCommand request, CancellationToken cancellationToken)
        {
            List<Movie> movies = _mapper.Map<List<Movie>>(request.Movies);

            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IMovieRepository>();
            await service.AddRangeAsync(movies);

            return Unit.Value;
        }
    }
}
