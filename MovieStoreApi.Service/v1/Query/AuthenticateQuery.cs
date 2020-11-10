using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Service.v1.Query
{
    public class AuthenticateQuery : IRequest<AuthenticateQueryResponse>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class AuthenticateQueryResponse
    {
        public string Token { get; set; }
    }
}
