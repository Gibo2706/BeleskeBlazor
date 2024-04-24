using BeleskeBlazor.Server.Repositoriums;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BeleskeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestriController : Controller
    {
        private readonly SemestarRepo _semRepo;

        public SemestriController(SemestarRepo semRepo)
        {
            _semRepo = semRepo;
        }

        [Route("getAllSemestri")]
        public async Task<ActionResult<List<SemestarDTO>>> getAllSemestri()
        {
            var list = await _semRepo.GetAllSemestri();

            List<SemestarDTO> semestri = list
                                        .Select(sem => ConverterDTO.getDTO(sem))
                                        .ToList();
            return Ok(semestri);
        }

        [Route("getSemestriPredmeta")]
        public async Task<ActionResult<List<SemestarDTO>>> getSemestriPredmeta(int id)
        {
            var list = await _semRepo.GetSemestriPredmeta(id);
            Console.WriteLine("id predmeta: " + id);
            List<SemestarDTO> semestri = list
                                        .Select(sem => ConverterDTO.getDTO(sem))
                                        .ToList();
            return Ok(semestri);
        }

    }
}
