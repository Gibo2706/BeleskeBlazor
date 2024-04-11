using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestarController : Controller
    {
        private readonly SemestarRepo _semRepo;
        
        public SemestarController(SemestarRepo semRepo)
        {
            _semRepo = semRepo;
        }


        [Route("getSemestriPredmeta")]
        public async Task<ActionResult<List<Semestar>>> getSemestriPredmeta(int id)
        {
            var list = await _semRepo.GetSemestriPredmeta(id);

            return Ok(list);
        }

    }
}
