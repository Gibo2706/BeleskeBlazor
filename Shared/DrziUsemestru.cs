using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
