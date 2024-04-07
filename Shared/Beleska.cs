using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Shared;

[Table("Beleska")]
public partial class Beleska
{
    [Key]
    public int IdBeleska { get; set; }

    [Column("redniBroj")]
    public int RedniBroj { get; set; }

    [Column("naslov")]
    public string Naslov { get; set; } = null!;

    [Column("dokument")]
    public byte[] Dokument { get; set; } = null!;

    [Column("idStudent")]
    public int IdStudent { get; set; }

    [Column("idCas")]
    public int IdCas { get; set; }

    [ForeignKey("IdCas")]
    [InverseProperty("Beleskas")]
    public virtual Ca IdCasNavigation { get; set; } = null!;

    [ForeignKey("IdStudent")]
    [InverseProperty("Beleskas")]
    public virtual Student IdStudentNavigation { get; set; } = null!;
}
