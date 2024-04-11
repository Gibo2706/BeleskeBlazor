using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
