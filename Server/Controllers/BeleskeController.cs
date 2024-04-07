using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeleskeController : ControllerBase
    {
        private readonly DataContext _context;

        public BeleskeController(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<Beleska>>> GetAllBeleske()
        {
            var list = await _context.Beleska.ToListAsync();
            return Ok(list);
        }

        [Route("Test")]
        public async Task<ActionResult<Beleska>> Test()
        {
            return Ok("Test");
        }
    }
}
