﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[Table("Beleska")]
public partial class Beleska
{
    [Key]
    public int IdBeleska { get; set; }

    [Column("redniBroj")]
    public int RedniBroj { get; set; }

    [Column("naslov")]
    public string Naslov { get; set; } = null!;

    [Column("dokument")]
    public byte[] Dokument { get; set; } = null!;

    [Column("idStudent")]
    public int? IdStudent { get; set; }

    [Column("idCas")]
    public int IdCas { get; set; }

    [ForeignKey("IdCas")]
    [InverseProperty("Beleskas")]
    public virtual Cas IdCasNavigation { get; set; } = null!;

    [ForeignKey("IdStudent")]
    [InverseProperty("Beleskas")]
    public virtual Student? IdStudentNavigation { get; set; }

    public record class BeleskaDTO(
            [property: JsonPropertyName("idBeleska")] int IdBeleska,
            [property: JsonPropertyName("redniBroj")] int RedniBroj,
            [property: JsonPropertyName("naslov")] string Naslov,
            [property: JsonPropertyName("dokument")] byte[] Dokument,
            [property: JsonPropertyName("idStudent")] int IdStudent,
            [property: JsonPropertyName("idCas")] int IdCas
        );

    public class BeleskaTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Check if conversion from string is supported
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {

                return new Beleska();
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Beleska beleska)
            {
                return beleska.IdBeleska + " - " + beleska.Naslov;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}