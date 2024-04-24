using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;
using BeleskeBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Beleska>> GetBeleskeDinamicno(int? predmet, int? brCasa,
                                                            string? imeAutora, string? prezimeAutora,
                                                            DateOnly? datumOd, DateOnly? datumDo,
                                                            string? naslov, int[]? idTagovi)
        {
            var dinamicniUpit = _context.Beleska.AsQueryable();

            if (predmet != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCas == predmet);

            if (brCasa != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.RedniBroj == brCasa);

            if (imeAutora != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdStudentNavigation != null &&
                                    b.IdStudentNavigation.Ime
                                    .StartsWith(imeAutora, StringComparison.OrdinalIgnoreCase));

            if (prezimeAutora != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdStudentNavigation != null &&
                                    b.IdStudentNavigation.Prezime
                                    .StartsWith(prezimeAutora, StringComparison.OrdinalIgnoreCase));

            if (datumOd != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.Datum >= datumOd);

            if (datumOd != null)
                dinamicniUpit = dinamicniUpit.Where(b => b.IdCasNavigation.Datum <= datumDo);

            if (naslov != null)
                dinamicniUpit = dinamicniUpit.Where(b =>
                                    b.Naslov.StartsWith(naslov, StringComparison.OrdinalIgnoreCase));

            if (idTagovi != null && idTagovi.Length != 0)
                dinamicniUpit = dinamicniUpit.Where(b => b.TagBeleskas
                                                    .Select<TagBeleska, int>(tb => tb.IdTag)
                                                    .Any(id => idTagovi.Contains(id))
                                             );
            return dinamicniUpit.ToList();
        }
    }
}
