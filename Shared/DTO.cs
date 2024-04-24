﻿using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared
{
    namespace DTO
    {
        public record class BeleskaDTO(
           [property: JsonPropertyName("idBeleska")] int IdBeleska,
           [property: JsonPropertyName("redniBroj")] int RedniBroj,
           [property: JsonPropertyName("naslov")] string Naslov,
           [property: JsonPropertyName("dokument")] byte[] Dokument,
           [property: JsonPropertyName("student")] StudentDTO? student,
           [property: JsonPropertyName("cas")] CasDTO cas,
           [property: JsonPropertyName("tagovi")] TagDTO[]? tagovi

        );
        public record class CasDTO(
            [property: JsonPropertyName("idCas")] int IdCas,
            [property: JsonPropertyName("redniBroj")] int RedniBroj,
            [property: JsonPropertyName("datum")] DateOnly Datum,
            [property: JsonPropertyName("vremePocetka")] DateTime VremePocetka,
            [property: JsonPropertyName("vremeKraja")] DateTime VremeKraja,
            [property: JsonPropertyName("profesor")] ProfesorDTO profesor,
            [property: JsonPropertyName("semestar")] SemestarDTO semestar
        );
        /*public record class DrziUsemestruDTO(
            [property: JsonPropertyName("idDrzi")] int IdDrzi,
            [property: JsonPropertyName("idProfesor")] int IdProfesor,
            [property: JsonPropertyName("idSemestar")] int IdSemestar,
            [property: JsonPropertyName("idPredmet")] int IdPredmet
        );*/
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
            [property: JsonPropertyName("ime")] string Ime,
            [property: JsonPropertyName("prezime")] string Prezime,
            [property: JsonPropertyName("username")] string Username
        );
        public record class TagDTO(
            [property: JsonPropertyName("idTag")] int IdTag,
            [property: JsonPropertyName("naziv")] string Naziv
        );
        /*public record class TagBeleskaDTO(
            [property: JsonPropertyName("idTagBeleska")] int IdTagBeleska,
            [property: JsonPropertyName("idTag")] int IdTag,
            [property: JsonPropertyName("idBeleska")] int IdBeleska
        );*/
    }
}
