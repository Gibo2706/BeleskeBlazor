using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[TypeConverter(typeof(CasTypeConverter))]
public partial class Cas
{
    [Key]
    [Column("idCas")]
    public int IdCas { get; set; }

    [Column("redniBroj")]
    public int RedniBroj { get; set; }

    [Column("datum")]
    public DateOnly Datum { get; set; }

    [Column("vremePocetka", TypeName = "datetime")]
    public DateTime VremePocetka { get; set; }

    [Column("vremeKraja", TypeName = "datetime")]
    public DateTime VremeKraja { get; set; }

    [Column("idDrzi")]
    public int IdDrzi { get; set; }

    [InverseProperty("IdCasNavigation")]
    public virtual ICollection<Beleska> Beleskas { get; set; } = new List<Beleska>();

    [ForeignKey("IdDrzi")]
    [InverseProperty("Cas")]
    public virtual DrziUsemestru IdDrziNavigation { get; set; } = null!;
}

public record class CasDTO(
        [property:JsonPropertyName("idCas")] int IdCas,
        [property: JsonPropertyName("redniBroj")] int RedniBroj,
        [property:JsonPropertyName("datum")] DateOnly Datum,
        [property:JsonPropertyName("vremePocetka")] DateTime VremePocetka,
        [property:JsonPropertyName("vremeKraja")] DateTime VremeKraja,
        [property:JsonPropertyName("idDrzi")] int IdDrzi
       );

public class CasTypeConverter : TypeConverter
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

            return new Cas();
        }

        return base.ConvertFrom(context, culture, value);
    }
}