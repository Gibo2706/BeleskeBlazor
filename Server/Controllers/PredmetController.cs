using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetController : Controller
    {
        private readonly DataContext _context;

        public PredmetController(DataContext context)
        {
            _context = context;
        }

        [Route("getCasoviPredmeta")]
        public async Task<ActionResult<List<Cas>>> GetCasoviPredmeta(int id)
        {
            var list = _context.Predmet.Find(id)
                        .DrziUsemestrus
                        .SelectMany(dus=>dus.Cas);
            return Ok(list);
        }
        
        public async Task<ActionResult<List<Predmet>>> GetAllPredmeti()
        {
            var list = await _context.Predmet.ToListAsync();
            return Ok(list);
        }
    }
}
