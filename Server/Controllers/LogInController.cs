using BeleskeBlazor.Shared.DTO;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Server.Repositoriums;
using System.Buffers.Text;

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

            if(student == null)
                return BadRequest("There is no username like this: "+username);

            if (!student.Password.Equals(System.Convert.ToBase64String(
                                                System.Text.Encoding.UTF8.GetBytes(password))))
                return BadRequest("Bad password");

            HttpContext.Session.SetInt32("UserId", student.IdStudent);
            
            return Ok("Logged in as user "+username);
        }

        [Route("logOut")]
        [HttpGet]
        public async Task<ActionResult<String>> logOut(int id)
        {
            HttpContext.Session.Remove("UserId");
            return Ok("Succesfully logged out!");
        }
    }
}
