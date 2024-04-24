using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasController : Controller
    {
        private readonly CasRepo _casRepo;

        public CasController(CasRepo casRepo)
        {
            _casRepo = casRepo;
        }
        [Route("getCasoviPredmetaUSemestru")]
        public async Task<ActionResult<List<CasDTO>>> GetCasoviPredmetaUSemestru(int semId, int predId)
        {
            List<Cas> list = await _casRepo.GetCasoviPredmetaUSemestru(semId, predId);

            List<CasDTO> casovi = list
                                .Select(c =>
                                {

                                    return ConverterDTO.getDTO(c);
                                })
                                .ToList();

            return Ok(casovi);
        }
    }
}
