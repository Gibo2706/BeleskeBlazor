using BeleskeBlazor.Shared.DTO;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("logIn")]
        [HttpPost]
        public async Task<ActionResult<String>> logIn(int id)
        {
            HttpContext.Session.SetString("UserId", "user123");
            return HttpContext.Session.GetString("UserId");
        }

        [Route("logOut")]
        [HttpGet]
        public async Task<ActionResult<String>> logOut(int id)
        {
            String a= HttpContext.Session.GetString("UserId");
            HttpContext.Session.Remove("UserId");
            return a;
        }
    }
}
