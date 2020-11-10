using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MovieStoreApi.Data.Context;
using MovieStoreApi.Data.Repository.v1;
using MovieStoreApi.Service.Models;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.v1.Query
{
    public class GetMovieQueryHandler :IRequestHandler<GetMovieQuery,GetMovieQueryResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;

        public GetMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper, IHttpContextAccessor context, MovieStoreContext movieStoreContext)
        {
            _mapper = mapper;
            _context = context;
            _movieRepository = movieRepository;
        }

        public async Task<GetMovieQueryResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var userClaim = _context.HttpContext.User.FindFirst(ClaimTypes.Name);
            int userId = Convert.ToInt32(userClaim.Value);

            var result = await _movieRepository.GetMoviesWithUserCritic(request.MovieId, userId);
            GetMovieQueryResponse response = new GetMovieQueryResponse
            {
                Movie = _mapper.Map<MovieModel>(result)
            };

            return response;
        }
    }
}
