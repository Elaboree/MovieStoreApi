using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Models.Core;
namespace MovieStoreApi.Controllers
{
    public class BaseController : Controller
    {
        public override JsonResult Json(object data)
        {
            return new JsonResult(new BaseResponse { Data = data, IsSucceeded = true, ErrorMessage = null });
        }
    }
}
