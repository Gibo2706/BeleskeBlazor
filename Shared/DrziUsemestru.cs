using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[Table("DrziUSemestru")]
public partial class DrziUsemestru
{
    [Key]
    [Column("idDrzi")]
    public int IdDrzi { get; set; }

    [Column("idProfesor")]
    public int IdProfesor { get; set; }

    [Column("idSemestar")]
    public int IdSemestar { get; set; }

    [Column("idPredmet")]
    public int IdPredmet { get; set; }

    [InverseProperty("IdDrziNavigation")]
    public virtual ICollection<Cas> Cas { get; set; } = new List<Cas>();

    [ForeignKey("IdPredmet")]
    [InverseProperty("DrziUsemestrus")]
    public virtual Predmet IdPredmetNavigation { get; set; } = null!;

    [ForeignKey("IdProfesor")]
    [InverseProperty("DrziUsemestrus")]
    public virtual Profesor IdProfesorNavigation { get; set; } = null!;

    [ForeignKey("IdSemestar")]
    [InverseProperty("DrziUsemestrus")]
    public virtual Semestar IdSemestarNavigation { get; set; } = null!;
}
public class DrziUSemestruTypeConverter : TypeConverter
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

            return new DrziUsemestru();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is DrziUsemestru drzi)
        {
            return drzi.IdProfesorNavigation.Ime + " - " + drzi.IdPredmetNavigation.Naziv;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}