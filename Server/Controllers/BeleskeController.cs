using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeleskeBlazor.Shared.DTO;


namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeleskeController : ControllerBase
    {
        private readonly BeleskaRepo _belRepo;

        public BeleskeController(BeleskaRepo belRepo)
        {
            _belRepo = belRepo;
        }
        [Route("getBeleskeCasa")]
        public async Task<ActionResult<List<BeleskaDTO>>> GetBeleskeCasa(int id)
        {
            var list = await _belRepo.GetBeleskeCasa(id);

            List<BeleskaDTO> beleske = list.Select(
                                        b => new BeleskaDTO(b.IdBeleska, b.RedniBroj, b.Naslov,
                                        b.Dokument, b.IdStudent, b.IdCas)).ToList();
            return Ok(beleske);
        }

        [Route("addBeleska")]
        public async Task<ActionResult> addBeleska(BeleskaDTO bdt)
        {
            if(await _belRepo.insertBeleska(bdt))
                return Ok();
            return BadRequest();
        }
    }
}
