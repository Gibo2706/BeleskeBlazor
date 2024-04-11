using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
