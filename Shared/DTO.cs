using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared
{
    namespace DTO
    {
        public record class BeleskaDTO(
           [property: JsonPropertyName("idBeleska")] int IdBeleska,
           [property: JsonPropertyName("redniBroj")] int RedniBroj,
           [property: JsonPropertyName("naslov")] string Naslov,
           [property: JsonPropertyName("dokument")] byte[] Dokument,
           [property: JsonPropertyName("idStudent")] int? IdStudent,
           [property: JsonPropertyName("idCas")] int IdCas
        );
        public record class CasDTO(
            [property: JsonPropertyName("idCas")] int IdCas,
            [property: JsonPropertyName("redniBroj")] int RedniBroj,
            [property: JsonPropertyName("datum")] DateOnly Datum,
            [property: JsonPropertyName("vremePocetka")] DateTime VremePocetka,
            [property: JsonPropertyName("vremeKraja")] DateTime VremeKraja
        );
        public record class DrziUsemestruDTO(
            [property: JsonPropertyName("idDrzi")] int IdDrzi,
            [property: JsonPropertyName("idProfesor")] int IdProfesor,
            [property: JsonPropertyName("idSemestar")] int IdSemestar,
            [property: JsonPropertyName("idPredmet")] int IdPredmet
        );
        public record class PredmetDTO(
            [property: JsonPropertyName("idPredmet")] int IdPredmet,
            [property: JsonPropertyName("naziv")] string Naziv
        );
        public record class ProfesorDTO(
            [property: JsonPropertyName("idProfesor")] int IdProfesor,
            [property: JsonPropertyName("ime")] string Ime,
            [property: JsonPropertyName("prezime")] string Prezime
        );
        public record class SemestarDTO(
            [property: JsonPropertyName("idSemestar")] int IdSemestar,
            [property: JsonPropertyName("godina")] String Godina,
            [property: JsonPropertyName("broj")] int Broj
        );
        public record class StudentDTO(
            [property: JsonPropertyName("idStudent")] int IdStudent,
            [property: JsonPropertyName("ime")] string Ime,
            [property: JsonPropertyName("prezime")] string Prezime,
            [property: JsonPropertyName("username")] string Username,
            [property: JsonPropertyName("password")] string Password
        );
        public record class TagDTO(
            [property: JsonPropertyName("idTag")] int IdTag,
            [property: JsonPropertyName("naziv")] string Naziv
        );
        public record class TagBeleskaDTO(
            [property: JsonPropertyName("idTagBeleska")] int IdTagBeleska,
            [property: JsonPropertyName("idTag")] int IdTag,
            [property: JsonPropertyName("idBeleska")] int IdBeleska
        );
    }
}
