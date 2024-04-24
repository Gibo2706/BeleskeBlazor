using BeleskeBlazor.Shared.DTO;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared
{
    namespace DTO
    {
        [TypeConverter(typeof(BeleskaDTOConverter))]
        public record class BeleskaDTO(
           [property: JsonPropertyName("idBeleska")] int IdBeleska,
           [property: JsonPropertyName("redniBroj")] int RedniBroj,
           [property: JsonPropertyName("naslov")] string Naslov,
           [property: JsonPropertyName("dokument")] byte[] Dokument,
           [property: JsonPropertyName("student")] StudentDTO? student,
           [property: JsonPropertyName("cas")] CasDTO cas,
           [property: JsonPropertyName("tagovi")] TagDTO[]? tagovi
        ) : ISerializable
        {
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return IdBeleska + "|" + RedniBroj + "|" + Naslov + "|" + System.Convert.ToBase64String(Dokument) + "|" + (student == null ? "null" : student.ToString()) + "|" + cas.ToString() + "|" + (tagovi == null ? "null" : string.Join<TagDTO>(";", tagovi));
            }
        }

        [TypeConverter(typeof(CasDTOConverter))]
        public record class CasDTO(
            [property: JsonPropertyName("idCas")] int IdCas,
            [property: JsonPropertyName("redniBroj")] int RedniBroj,
            [property: JsonPropertyName("datum")] DateOnly Datum,
            [property: JsonPropertyName("vremePocetka")] DateTime VremePocetka,
            [property: JsonPropertyName("vremeKraja")] DateTime VremeKraja,
            [property: JsonPropertyName("profesor")] ProfesorDTO profesor,
            [property: JsonPropertyName("semestar")] SemestarDTO semestar
        ) : ISerializable
        {
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return IdCas + "|" + RedniBroj + "|" + Datum + "|" + VremePocetka + "|" + VremeKraja + "|" + profesor.ToString() + "|" + semestar.ToString();
            }
        }
        /*public record class DrziUsemestruDTO(
            [property: JsonPropertyName("idDrzi")] int IdDrzi,
            [property: JsonPropertyName("idProfesor")] int IdProfesor,
            [property: JsonPropertyName("idSemestar")] int IdSemestar,
            [property: JsonPropertyName("idPredmet")] int IdPredmet
        );*/
        [TypeConverter(typeof(PredmetDTOConverter))]
        public record class PredmetDTO(
            [property: JsonPropertyName("idPredmet")] int IdPredmet,
            [property: JsonPropertyName("naziv")] string Naziv
        ) : ISerializable
        {
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return IdPredmet + "|" + Naziv;
            }
        }
        [TypeConverter(typeof(ProfesorDTOConverter))]
        public record class ProfesorDTO(
            [property: JsonPropertyName("idProfesor")] int IdProfesor,
            [property: JsonPropertyName("ime")] string Ime,
            [property: JsonPropertyName("prezime")] string Prezime
        ) : ISerializable
        {
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return IdProfesor + "|" + Ime + "|" + Prezime;
            }
        }
        [TypeConverter(typeof(SemestarDTOConverter))]
        public record class SemestarDTO(
            [property: JsonPropertyName("idSemestar")] int IdSemestar,
            [property: JsonPropertyName("godina")] String Godina,
            [property: JsonPropertyName("broj")] int Broj
        ) : ISerializable
        {
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return IdSemestar + "|" + Godina + "|" + Broj;
            }
        }
        [TypeConverter(typeof(StudentDTOConverter))]
        public record class StudentDTO(
            [property: JsonPropertyName("ime")] string Ime,
            [property: JsonPropertyName("prezime")] string Prezime,
            [property: JsonPropertyName("username")] string Username
        )
        {
            public override string ToString()
            {
                return Ime + "|" + Prezime + "|" + Username;
            }
        }
        [TypeConverter(typeof(TagDTOConverter))]
        public record class TagDTO(
            [property: JsonPropertyName("idTag")] int IdTag,
            [property: JsonPropertyName("naziv")] string Naziv
        )
        {
            public override string ToString()
            {
                return IdTag + "|" + Naziv;
            }
        }
        /*public record class TagBeleskaDTO(
            [property: JsonPropertyName("idTagBeleska")] int IdTagBeleska,
            [property: JsonPropertyName("idTag")] int IdTag,
            [property: JsonPropertyName("idBeleska")] int IdBeleska
        );*/
    }
    public class BeleskaDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // Parse the string and construct the BeleskaDTO instance
                // You'll need to implement your own parsing logic based on the string format
                return ParseBeleskaDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        private BeleskaDTO ParseBeleskaDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 7)
            {
                throw new FormatException("Invalid format for BeleskaDTO string.");
            }

            int idBeleska = int.Parse(splitValues[0]);
            int redniBroj = int.Parse(splitValues[1]);
            string naslov = splitValues[2];
            byte[] dokument = Convert.FromBase64String(splitValues[3]);
            StudentDTO student = splitValues[4] == "null" ? null : StudentDTOConverter.ParseStudentDTOFromString(splitValues[4]);
            CasDTO cas = CasDTOConverter.ParseCasDTOFromString(splitValues[5]);
            TagDTO[] tagovi = splitValues[6] == "null" ? null : TagDTOConverter.ParseTagDTOArrayFromString(splitValues[6]);

            return new BeleskaDTO(idBeleska, redniBroj, naslov, dokument, student, cas, tagovi);
        }
    }

    public class CasDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                return ParseCasDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static CasDTO ParseCasDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 7)
            {
                throw new FormatException("Invalid format for CasDTO string.");
            }

            int idCas = int.Parse(splitValues[0]);
            int redniBroj = int.Parse(splitValues[1]);
            DateOnly datum = DateOnly.Parse(splitValues[2]);
            DateTime vremePocetka = DateTime.Parse(splitValues[3]);
            DateTime vremeKraja = DateTime.Parse(splitValues[4]);
            ProfesorDTO profesor = ProfesorDTOConverter.ParseProfesorDTOFromString(splitValues[5]);
            SemestarDTO semestar = SemestarDTOConverter.ParseSemestarDTOFromString(splitValues[6]);

            return new CasDTO(idCas, redniBroj, datum, vremePocetka, vremeKraja, profesor, semestar);
        }
    }

    public class PredmetDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                return ParsePredmetDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static PredmetDTO ParsePredmetDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 2)
            {
                throw new FormatException("Invalid format for PredmetDTO string.");
            }

            int idPredmet = int.Parse(splitValues[0]);
            string naziv = splitValues[1];

            return new PredmetDTO(idPredmet, naziv);
        }
    }

    public class ProfesorDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // Parse the string and construct the ProfesorDTO instance
                // You'll need to implement your own parsing logic based on the string format
                return ParseProfesorDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static ProfesorDTO ParseProfesorDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 3)
            {
                throw new FormatException("Invalid format for ProfesorDTO string.");
            }

            int idProfesor = int.Parse(splitValues[0]);
            string ime = splitValues[1];
            string prezime = splitValues[2];

            return new ProfesorDTO(idProfesor, ime, prezime);
        }
    }

    public class SemestarDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // Parse the string and construct the SemestarDTO instance
                // You'll need to implement your own parsing logic based on the string format
                return ParseSemestarDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static SemestarDTO ParseSemestarDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 3)
            {
                throw new FormatException("Invalid format for SemestarDTO string.");
            }

            int idSemestar = int.Parse(splitValues[0]);
            string godina = splitValues[1];
            int broj = int.Parse(splitValues[2]);

            return new SemestarDTO(idSemestar, godina, broj);
        }
    }

    public class StudentDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // Parse the string and construct the StudentDTO instance
                // You'll need to implement your own parsing logic based on the string format
                return ParseStudentDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }
        public static StudentDTO ParseStudentDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 3)
            {
                throw new FormatException("Invalid format for StudentDTO string.");
            }

            string ime = splitValues[0];
            string prezime = splitValues[1];
            string username = splitValues[2];

            return new StudentDTO(ime, prezime, username);
        }
    }

    public class TagDTOConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // Parse the string and construct the TagDTO instance
                // You'll need to implement your own parsing logic based on the string format
                return ParseTagDTOFromString(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static TagDTO ParseTagDTOFromString(string stringValue)
        {
            var splitValues = stringValue.Split('|'); // Assuming '|' separates properties in the string

            if (splitValues.Length != 2)
            {
                throw new FormatException("Invalid format for TagDTO string.");
            }

            int idTag = int.Parse(splitValues[0]);
            string naziv = splitValues[1];

            return new TagDTO(idTag, naziv);
        }

        public static TagDTO[] ParseTagDTOArrayFromString(string stringValue)
        {
            if (stringValue == "null")
            {
                return null;
            }

            var tagStrings = stringValue.Split(';'); // Assuming ';' separates individual TagDTO strings
            var tagList = new List<TagDTO>();

            foreach (var tagString in tagStrings)
            {
                tagList.Add(ParseTagDTOFromString(tagString));
            }

            return tagList.ToArray();
        }
    }
}

