﻿using BeleskeBlazor.Server.Repositoriums;
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


        [Route("getSemestriPredmeta")]
        public async Task<ActionResult<List<SemestarDTO>>> getSemestriPredmeta(int id)
        {
            var list = await _semRepo.GetSemestriPredmeta(id);
            Console.WriteLine("id predmeta: " + id);
            List<SemestarDTO> semestri = list.Select(sem =>
                                          new SemestarDTO(sem.IdSemestar, sem.SkolskaGodina, sem.Broj))
                                         .ToList();
            return Ok(semestri);
        }

    }
}
