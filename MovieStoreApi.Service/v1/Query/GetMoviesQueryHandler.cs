using AutoMapper;
using MediatR;
using MovieStoreApi.Data.Repository.v1;
using MovieStoreApi.Service.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.v1.Query
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, GetMoviesQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public GetMoviesQueryHandler(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<GetMoviesQueryResponse> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetMoviesByPageSizeAsync(request.PageIndex, request.PageSize);

            GetMoviesQueryResponse response = new GetMoviesQueryResponse
            {
                Movies = _mapper.Map<List<MovieModel>>(result)
            };

            return response;
        }
    }
}
