using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[Table("Tag")]
public partial class Tag
{
    [Key]
    [Column("idTag")]
    public int IdTag { get; set; }

    [Column("naziv")]
    [StringLength(255)]
    [Unicode(false)]
    public string Naziv { get; set; } = null!;

    [InverseProperty("IdTagNavigation")]
    public virtual ICollection<TagBeleska> TagBeleskas { get; set; } = new List<TagBeleska>();
}


public record class TagDTO(
       [property: JsonPropertyName("idTag")] int IdTag,
          [property: JsonPropertyName("naziv")] string Naziv
       );


public class TagTypeConverter : TypeConverter
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
            return new Tag();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is Tag tag)
        {
            return tag.IdTag + " - " + tag.Naziv;
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}