using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasController : Controller
    {
        private readonly DataContext _context;
       
        public CasController(DataContext context) { 
            _context = context;
        }

        public async Task<ActionResult<List<Cas>>> GetAllCas()
        {
            var list = await _context.Cas.ToListAsync();
            return Ok(list);
        }
    }
}
