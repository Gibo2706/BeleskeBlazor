using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using BeleskeBlazor.Shared;


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
        [HttpPost]
        public async Task<ActionResult> addBeleska([FromBody] BeleskaDTO bdt, [FromBody] Boolean jeUlogovan)
        {
            //Llgika da li je anoniman

            if (await _belRepo.insertBeleska(bdt, null))
                return Ok();
            return BadRequest();
        }

        [Route("getBeleskeDinamicno")]
        public async Task<ActionResult> GetBeleskeDinamicno(int? predmet, int? brCasa,
                                                            string? imeAutora, string? prezimeAutora,
                                                            DateOnly? datumOd, DateOnly? datumDo,
                                                            string? naslov, int[]? idTagovi)
        {
            var list = await _belRepo.GetBeleskeDinamicno(predmet, brCasa, imeAutora, prezimeAutora,
                                      datumOd, datumDo, naslov, idTagovi);

            List<BeleskaDTO> beleske = list
                                    .Select(b => ConverterDTO.getDTO(b))
                                    .ToList();
            return Ok(beleske);
        }
    }
}
