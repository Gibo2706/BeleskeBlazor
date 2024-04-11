using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
