using MediatR;
using Microsoft.AspNetCore.Http;
using MovieStoreApi.Data.Repository.v1;
using MovieStoreApi.Domain;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.v1.Command
{
    public class AddMovieCriticCommandHandler : IRequestHandler<AddMovieCriticCommand>
    {
        private readonly ICriticRepository _criticRepository;
        private readonly IHttpContextAccessor _context;

        public AddMovieCriticCommandHandler(ICriticRepository criticRepository, IHttpContextAccessor context)
        {
            _criticRepository = criticRepository;
            _context = context;
        }
        public async Task<Unit> Handle(AddMovieCriticCommand request, CancellationToken cancellationToken)
        {
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            Critic critic = new Critic
            {
                UserId = Convert.ToInt32(userId),
                MovieId = request.MovieId,
                Rating = request.Rating,
                Comment = request.Comment
            };

            await _criticRepository.AddAsync(critic);
            return Unit.Value;
        }
    }
}
