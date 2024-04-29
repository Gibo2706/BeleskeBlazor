using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;


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

            List<BeleskaDTO> beleske = list
                                    .Select(b => ConverterDTO.getDTO(b))
                                    .ToList();
            return Ok(beleske);
        }


        [Route("addBeleska")]
        [HttpPost("{jeUlogovan}")]
        public async Task<ActionResult> addBeleska([FromBody] BeleskaDTO bdt, [FromQuery] Boolean jeUlogovan)
        {
            int? idS = HttpContext.Session.GetInt32("UserId");

            if (jeUlogovan && idS == null)
                return BadRequest("Session expired, log in again");

            if (await _belRepo.insertBeleska(bdt, idS))
                return Ok();
            else
                return BadRequest();
        }

        [Route("getBeleskeDinamicno")]
        [HttpPost]
        public async Task<ActionResult> GetBeleskeDinamicno(int? predmet, int? brCasa, int? semestar,
                                                            string? imeAutora, string? prezimeAutora,
                                                            DateOnly? datumOd, DateOnly? datumDo,
                                                            string? naslov, [FromBody] int[]? idTagovi, Boolean? moje)
        {
            int? idS = HttpContext.Session.GetInt32("UserId");

            if (moje != null && moje.Value && idS == null)
            {
                return BadRequest("You need to log in to see your notes.");
            }

            var list = await _belRepo.GetBeleskeDinamicno(predmet, brCasa, semestar, imeAutora, prezimeAutora,
                                      datumOd, datumDo, idS, naslov, idTagovi, moje);
            Console.WriteLine("List size: " + idTagovi);

            List<BeleskaDTO> beleske = list
                                    .Select(b => ConverterDTO.getDTO(b))
                                    .ToList();
            return Ok(beleske);
        }
    }
}
