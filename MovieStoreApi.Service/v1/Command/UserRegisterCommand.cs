using MediatR;
using MovieStoreApi.Service.Models;

namespace MovieStoreApi.Service.v1.Command
{
    public class UserRegisterCommand:IRequest
    {
        public UserRegisterModel UserRegisterModel { get; set; }
    }
}
