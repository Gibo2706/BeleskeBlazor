using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BeleskeBlazor.Shared;

[Table("Predmet")]
[TypeConverter(typeof(PredmetTypeConverter))]
public partial class Predmet
{
    [Key]
    [Column("idPredmet")]
    public int IdPredmet { get; set; }

    [Column("naziv")]
    [StringLength(255)]
    [Unicode(false)]
    public string Naziv { get; set; } = null!;

    [InverseProperty("IdPredmetNavigation")]
    public virtual ICollection<DrziUsemestru> DrziUsemestrus { get; set; } = new List<DrziUsemestru>();

    public override string ToString()
    {
        return "{" + IdPredmet + "} " + Naziv;
    }
}

public class PredmetTypeConverter : TypeConverter
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

            return new Predmet();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is Predmet predmet)
        {
            return predmet.IdPredmet + " - " + predmet.Naziv;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }

}
