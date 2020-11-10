using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieStoreApi.Data.Context;
using MovieStoreApi.Domain;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.v1.Query
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, AuthenticateQueryResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly MovieStoreContext _movieStoreContext;
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _context;
        public AuthenticateQueryHandler(SignInManager<User> signInManager, MovieStoreContext movieStoreContext, IOptions<AppSettings> options, IHttpContextAccessor context)
        {
            _signInManager = signInManager;
            _movieStoreContext = movieStoreContext;
            _appSettings = options.Value;
            _context = context;
        }

        public async Task<AuthenticateQueryResponse> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            User user = _movieStoreContext.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(userId));

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if(!result.Succeeded)
            {
                throw new Exception("Username or password wrong!");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            AuthenticateQueryResponse response = new AuthenticateQueryResponse();
            response.Token = tokenHandler.WriteToken(token);

            return response;
        }
    }
}
