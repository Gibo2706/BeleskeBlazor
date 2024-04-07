using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Shared;

[Table("Semestar")]
public partial class Semestar
{
    [Key]
    [Column("idSemestar")]
    public int IdSemestar { get; set; }

    [Column("broj")]
    public int Broj { get; set; }

    [InverseProperty("IdSemestarNavigation")]
    public virtual ICollection<DrziUsemestru> DrziUsemestrus { get; set; } = new List<DrziUsemestru>();
}
