using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BeleskeBlazor.Server.Repositoriums
{
    public class BeleskaRepo
    {
        private readonly DataContext _context;

        public BeleskaRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> insertBeleska(BeleskaDTO bdt)
        {
            try
            {
                Beleska b = new Beleska();
                b.Naslov = bdt.Naslov;
                b.IdStudent = bdt.IdStudent;
                b.Dokument = bdt.Dokument;
                b.RedniBroj = bdt.RedniBroj;
                b.IdCas = bdt.IdCas;

                _context.Beleska.Add(b);

                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Beleska>> GetBeleskeCasa(int id)
        {
            List<Beleska> list = _context.Beleska
                                .Where(b=> b.IdCas==id)
                                .ToList();
            return list;
        }
    }
}
