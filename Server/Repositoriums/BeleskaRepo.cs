using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BeleskeBlazor.Server.Repositoriums
{
    public class BeleskaRepo
    {
        private readonly DataContext _context;

        public BeleskaRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> insertBeleska(BeleskaDTO bdt, int? student)
        {
            try
            {
                Beleska b = new Beleska();
                b.Naslov = bdt.Naslov;
                b.IdStudent = student;
                b.Dokument = bdt.Dokument;
                b.IdCas = bdt.cas.IdCas;

                b.RedniBroj = _context.Beleska
                                .Where(bel => bel.IdStudent == b.IdStudent &&
                                        bel.IdCas == b.IdCas)
                                .Count() + 1;//Redni broj pocinje od 1.

                _context.Beleska.Add(b);
                _context.SaveChanges();

                if (bdt.tagovi != null && bdt.tagovi.Length!=0)
                {
                    b.TagBeleskas = bdt.tagovi.Select(t =>
                    {
                        TagBeleska tb = new TagBeleska();
                        tb.IdBeleska = b.IdBeleska;
                        tb.IdTag = t.IdTag;
                        _context.TagBeleska.Add(tb);
                        return tb;
                    }).ToList();
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Beleska>> GetBeleskeCasa(int id)
        {
            List<Beleska> list = _context.Beleska
                                .Where(b => b.IdCas == id)
                                .ToList();
            return list;
        }

        public async Task<List<Beleska>> GetBeleskeDinamicno(int? predmet, int? brCasa, int? semestar,
                                                            string? imeAutora, string? prezimeAutora,
                                                            DateOnly? datumOd, DateOnly? datumDo, int? idS,
                                                            string? naslov, int[]? idTagovi, Boolean? moje)
        {
            var dinamicniUpit = _context.Beleska.AsQueryable();

            if (moje != null && moje.Value)//U kontroleru se proveri da li je ulogovan ako hoce da lista svoje
                dinamicniUpit = dinamicniUpit.Where(b => b.IdStudent == idS);

            if (predmet != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.IdDrziNavigation.IdPredmet == predmet);

            if (brCasa != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.RedniBroj == brCasa);

            if (semestar != null)
                dinamicniUpit = dinamicniUpit.Where(b =>
                                                b.IdCasNavigation.IdDrziNavigation.IdSemestar == semestar);

            if (imeAutora != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdStudentNavigation != null && 
                                            EF.Functions.Like(
                                                b.IdStudentNavigation.Ime, "%" + imeAutora + "%"));

            if (prezimeAutora != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdStudentNavigation != null &&
                                    EF.Functions.Like(
                                        b.IdStudentNavigation.Prezime, "%" + prezimeAutora + "%"));

            if (datumOd != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.Datum >= datumOd);

            if (datumOd != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.Datum <= datumDo);

            if (naslov != null)
                dinamicniUpit = dinamicniUpit.Where(b =>
                                    EF.Functions.Like(b.Naslov, "%"+naslov+"%"));

            if (idTagovi != null && idTagovi.Length != 0)
                dinamicniUpit = dinamicniUpit.Where(b => b.TagBeleskas
                                                    .Select<TagBeleska, int>(tb => tb.IdTag)
                                                    .Any(id => idTagovi.Contains(id))
                                             );
            return dinamicniUpit.ToList();
        }
    }
}
