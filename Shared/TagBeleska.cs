using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
