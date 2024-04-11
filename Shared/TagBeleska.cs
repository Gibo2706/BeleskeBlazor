using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[Table("TagBeleska")]
[Index("IdTagBeleska", "IdTag", Name = "TagBeleska_const", IsUnique = true)]
public partial class TagBeleska
{
    [Key]
    [Column("idTagBeleska")]
    public int IdTagBeleska { get; set; }

    [Column("idTag")]
    public int IdTag { get; set; }

    [Column("idBeleska")]
    public int IdBeleska { get; set; }

    [ForeignKey("IdBeleska")]
    [InverseProperty("TagBeleskas")]
    public virtual Beleska IdBeleskaNavigation { get; set; } = null!;

    [ForeignKey("IdTag")]
    [InverseProperty("TagBeleskas")]
    public virtual Tag IdTagNavigation { get; set; } = null!;
}
public class TagBeleskaTypeConverter : TypeConverter
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
            return new TagBeleska();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is TagBeleska tagBeleska)
        {
            return tagBeleska.IdTagBeleska + " - " + tagBeleska.IdTag + " - " + tagBeleska.IdBeleska;
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}