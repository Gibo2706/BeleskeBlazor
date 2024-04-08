using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Shared;

public partial class Cas
{
    [Key]
    [Column("idCas")]
    public int IdCas { get; set; }

    [Column("redniBroj")]
    public int RedniBroj { get; set; }

    [Column("datum")]
    public DateOnly Datum { get; set; }

    [Column("vremePocetka", TypeName = "datetime")]
    public DateTime VremePocetka { get; set; }

    [Column("vremeKraja", TypeName = "datetime")]
    public DateTime VremeKraja { get; set; }

    [Column("idDrzi")]
    public int IdDrzi { get; set; }

    [InverseProperty("IdCasNavigation")]
    public virtual ICollection<Beleska> Beleskas { get; set; } = new List<Beleska>();

    [ForeignKey("IdDrzi")]
    [InverseProperty("Cas")]
    public virtual DrziUsemestru IdDrziNavigation { get; set; } = null!;
}
