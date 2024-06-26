﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BeleskeBlazor.Shared;

[Table("Semestar")]
[Index("Broj", "SkolskaGodina", Name = "Semestar_ix1", IsUnique = true)]
public partial class Semestar
{
    [Key]
    [Column("idSemestar")]
    public int IdSemestar { get; set; }

    [Column("broj")]
    public int Broj { get; set; }

    [Column("skolskaGodina")]
    [StringLength(15)]
    [Unicode(false)]
    public string SkolskaGodina { get; set; } = null!;

    [InverseProperty("IdSemestarNavigation")]
    public virtual ICollection<DrziUsemestru> DrziUsemestrus { get; set; } = new List<DrziUsemestru>();
}

public class SemestarTypeConverter : TypeConverter
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

            return new Semestar();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is Semestar sem)
        {
            return sem.IdSemestar + " - " + sem.Broj;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}