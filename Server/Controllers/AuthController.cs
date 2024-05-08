using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly StudentRepo _studRepo;

        public AuthController(StudentRepo studRepo)
        {
            _studRepo = studRepo;
        }

        [Route("continueSess")]
        [HttpGet]
        public async Task<ActionResult<String>> continueSess()
        {
            int? idS = HttpContext.Session.GetInt32("UserId");

            if (!idS.HasValue)
                return BadRequest("Session expired");

            return Ok("Session renewed for 5 more minutes");
        }

        [Route("logIn")]
        [HttpGet]
        public async Task<ActionResult<String>> logIn(String username, String password)
        {
            Console.WriteLine(System.Convert.ToBase64String(
                                                System.Text.Encoding.UTF8.GetBytes(password)));
            int? idS = HttpContext.Session.GetInt32("UserId");

            if (idS.HasValue)
                return BadRequest("You are already logged in");

            Student? student = _studRepo.getByUsername(username);

            if (student == null)
                return BadRequest("There is no username like this: " + username);

            if (!student.Password.Equals(System.Convert.ToBase64String(
                                                System.Text.Encoding.UTF8.GetBytes(password))))
                return BadRequest("Bad password");

            HttpContext.Session.SetInt32("UserId", student.IdStudent);
            HttpContext.Session.SetString("username", student.Username);

            return Ok("Logged in as user " + username);
        }

        [Route("getLoggedUser")]
        [HttpGet]
        public async Task<ActionResult<String>> getLoggedUser()
        {
            string? stud = HttpContext.Session.GetString("username");
            return Ok(stud);
        }

        [Route("logOut")]
        [HttpGet]
        public async Task<ActionResult<String>> logOut()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("username");
            return Ok("Succesfully logged out!");
        }
    }
}
