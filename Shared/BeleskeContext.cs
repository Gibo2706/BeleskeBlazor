using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Shared;

public partial class BeleskeContext : DbContext
{
    public BeleskeContext()
    {
    }

    public BeleskeContext(DbContextOptions<BeleskeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beleska> Beleskas { get; set; }

    public virtual DbSet<Ca> Cas { get; set; }

    public virtual DbSet<DrziUsemestru> DrziUsemestrus { get; set; }

    public virtual DbSet<Predmet> Predmets { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Semestar> Semestars { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=seminarskic.database.windows.net; Database=Beleske; User=Jasmin;Password=Beleske123!jevrej; Trusted_Connection=false; Encrypt=true; TrustServerCertificate=true", x => x.UseDateOnlyTimeOnly());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beleska>(entity =>
        {
            entity.HasKey(e => e.IdBeleska).HasName("PK_Beleske");

            entity.HasOne(d => d.IdCasNavigation).WithMany(p => p.Beleskas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Beleska_Cas");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Beleskas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Beleska_Student");
        });

        modelBuilder.Entity<Ca>(entity =>
        {
            entity.HasKey(e => e.IdCas).HasName("PK__Cas__398E4042983BE281");

            entity.HasOne(d => d.IdDrziNavigation).WithMany(p => p.Cas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cas_Drzi");
        });

        modelBuilder.Entity<DrziUsemestru>(entity =>
        {
            entity.HasKey(e => e.IdDrzi).HasName("PK__DrziUSem__DF5BA2D9D8A11189");

            entity.HasOne(d => d.IdPredmetNavigation).WithMany(p => p.DrziUsemestrus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DrziUSemestru_Predmet");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.DrziUsemestrus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DrziUSemestru_Profesor");

            entity.HasOne(d => d.IdSemestarNavigation).WithMany(p => p.DrziUsemestrus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DrziUSemestru_Semestar");
        });

        modelBuilder.Entity<Predmet>(entity =>
        {
            entity.HasKey(e => e.IdPredmet).HasName("PK__Predmet__2C2B78975DFCD7EE");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__E4BBA604E614A306");
        });

        modelBuilder.Entity<Semestar>(entity =>
        {
            entity.HasKey(e => e.IdSemestar).HasName("PK__Semestar__C6BF30205996DFC2");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent).HasName("PK__Student__35B1F88A3B5EF8CC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
