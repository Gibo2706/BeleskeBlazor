using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeleskeBlazor.Server.Repositoriums
{
    public class SemestarRepo
    {
        private readonly DataContext _context;

        public SemestarRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Semestar>> GetSemestriPredmeta(int id)
        {
            List <Semestar> list = _context.Predmet
                        .SelectMany(p=> p.DrziUsemestrus)
                        .Where(dus=> dus.IdPredmet==id)
                        .Select(dus => dus.IdSemestarNavigation).ToList<Semestar>();
            return list;
        }
    }
}
