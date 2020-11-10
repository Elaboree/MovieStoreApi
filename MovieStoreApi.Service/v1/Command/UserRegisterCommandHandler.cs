using MediatR;
using System.Threading;
using MovieStoreApi.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MovieStoreApi.Service.v1.Command
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand>
    {
        private readonly UserManager<User> _userManager;
        public UserRegisterCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            User registerUser = new User
            {
                UserName = request.UserRegisterModel.Name,
                Email = request.UserRegisterModel.Email
            };
            await _userManager.CreateAsync(registerUser, request.UserRegisterModel.Password);

            return Unit.Value;
        }
    }
}
