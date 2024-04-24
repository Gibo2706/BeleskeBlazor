using BeleskeBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeleskeBlazor.Shared
{
    public class ConverterDTO
    {
        public static BeleskaDTO getDTO(Beleska beleska)
        {
            TagDTO[] tagovi=beleska.TagBeleskas
                            .Select(tb=> getDTO(tb.IdTagNavigation))
                            .ToArray();

            return new BeleskaDTO(beleska.IdBeleska, beleska.RedniBroj, beleska.Naslov,
                                 beleska.Dokument, getDTO(beleska.IdStudentNavigation), 
                                 getDTO(beleska.IdCasNavigation), tagovi);
        }

        public static PredmetDTO getDTO(Predmet predmet)
        {
            return new PredmetDTO(predmet.IdPredmet, predmet.Naziv);
        }

        public static StudentDTO getDTO(Student? student)
        {
            if (student == null)
                return null;
            return new StudentDTO(student.Ime, student.Prezime, student.Username);
        }

        public static TagDTO getDTO(Tag tag)
        {
            return new TagDTO(tag.IdTag, tag.Naziv);
        }

        public static CasDTO getDTO(Cas cas)
        {
            return new CasDTO(cas.IdCas, cas.RedniBroj, cas.Datum, 
                                cas.VremePocetka, cas.VremeKraja,
                                getDTO(cas.IdDrziNavigation.IdProfesorNavigation), 
                                getDTO(cas.IdDrziNavigation.IdSemestarNavigation),
                                getDTO(cas.IdDrziNavigation.IdPredmetNavigation));
        }

        public static ProfesorDTO getDTO(Profesor profesor)
        {
            return new ProfesorDTO(profesor.IdProfesor, profesor.Ime, profesor.Prezime);
        }

        public static SemestarDTO getDTO(Semestar semestar) 
        {
            return new SemestarDTO(semestar.IdSemestar, semestar.SkolskaGodina, semestar.Broj);
        }
    }
}
