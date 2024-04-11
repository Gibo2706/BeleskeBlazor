using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetiController : Controller
    {
        private readonly PredmetRepo _predRepo;

        public PredmetiController(PredmetRepo predmetRepo)
        {
            _predRepo = predmetRepo;
        }
        
        public async Task<ActionResult<List<PredmetDTO>>> GetAllPredmeti()
        {
            var list = await _predRepo.GetAllPredmeti();

            List<PredmetDTO> predmeti= list.Select(pr=>
                                         new PredmetDTO(pr.IdPredmet, pr.Naziv))
                                        .ToList();
            return Ok(list);
        }
    }
}
