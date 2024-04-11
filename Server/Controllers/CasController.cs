using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasController : Controller
    {
        private readonly CasRepo _casRepo;
       
        public CasController(CasRepo casRepo) {
            _casRepo = casRepo;
        }
        [Route("getCasoviPredmetaUSemestru")]
        public async Task<ActionResult<List<CasDTO>>> GetCasoviPredmetaUSemestru(int semId, int predId)
        {
            List<Cas> list = await _casRepo.GetCasoviPredmetaUSemestru(semId, predId);

            List<CasDTO> casovi = list.Select(c =>
                                  new CasDTO(c.IdCas, c.RedniBroj, c.Datum, c.VremePocetka, c.VremeKraja))
                                .ToList();

            return Ok(casovi);
        }
    }
}
