using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Shared;

[Table("Predmet")]
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
}
