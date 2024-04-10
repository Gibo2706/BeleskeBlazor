using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BeleskeBlazor.Shared;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("idStudent")]
    public int IdStudent { get; set; }

    [Column("ime")]
    [StringLength(255)]
    [Unicode(false)]
    public string Ime { get; set; } = null!;

    [Column("prezime")]
    [StringLength(255)]
    [Unicode(false)]
    public string Prezime { get; set; } = null!;

    [Column("username")]
    [StringLength(255)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [InverseProperty("IdStudentNavigation")]
    public virtual ICollection<Beleska> Beleskas { get; set; } = new List<Beleska>();
}

public class StudentTypeConverter : TypeConverter
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

            return new Student();
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is Student stud)
        {
            return stud.IdStudent + " - " + stud.Ime;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}