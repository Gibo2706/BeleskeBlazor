using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[Table("Profesor")]
[TypeConverter(typeof(ProfesorTypeConverter))]
public partial class Profesor
{
    [Key]
    [Column("idProfesor")]
    public int IdProfesor { get; set; }

    [Column("ime")]
    [StringLength(255)]
    [Unicode(false)]
    public string Ime { get; set; } = null!;

    [Column("prezime")]
    [StringLength(255)]
    [Unicode(false)]
    public string Prezime { get; set; } = null!;

    [InverseProperty("IdProfesorNavigation")]
    public virtual ICollection<DrziUsemestru> DrziUsemestrus { get; set; } = new List<DrziUsemestru>();
}

public record class ProfesorDTO(
        [property:JsonPropertyName("idProfesor")] int IdProfesor,
        [property: JsonPropertyName("ime")] string Ime,
        [property:JsonPropertyName("prezime")] string Prezime
    );

public class ProfesorTypeConverter : TypeConverter
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

            return new Profesor();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is Profesor prof)
        {
            return prof.IdProfesor + " - " + prof.Ime;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}