using BeleskeBlazor.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeleskeBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);

        }

        public virtual DbSet<Beleska> Beleska { get; set; }

        public virtual DbSet<Cas> Cas { get; set; }

        public virtual DbSet<Predmet> Predmet { get; set; }

        public virtual DbSet<Semestar> Semestar { get; set; }

        public virtual DbSet<Student> Student { get; set; }

        public virtual DbSet<Tag> Tag { get; set; }

        public virtual DbSet<TagBeleska> TagBeleska { get; set; }

        public virtual DbSet<DrziUsemestru> DrziUsemestru { get; set; }

        public virtual DbSet<Profesor> Profesor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Beleska>(entity =>
            {
                entity.HasKey(e => e.IdBeleska).HasName("PK_Beleske");

                entity.HasOne(d => d.IdCasNavigation).WithMany(p => p.Beleskas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Beleska_Cas");

                entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Beleskas).HasConstraintName("Beleska_Student");
            });

            modelBuilder.Entity<Beleska>().Navigation(b => b.IdCasNavigation).AutoInclude();
            modelBuilder.Entity<Beleska>().Navigation(b => b.IdStudentNavigation).AutoInclude();
            modelBuilder.Entity<Beleska>().Navigation(b => b.TagBeleskas).AutoInclude();
            modelBuilder.Entity<Cas>(entity =>
            {
                entity.HasKey(e => e.IdCas).HasName("PK__Cas__398E4042983BE281");

                entity.HasOne(d => d.IdDrziNavigation).WithMany(p => p.Cas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cas_Drzi");
            });
            modelBuilder.Entity<Cas>().Navigation(c => c.IdDrziNavigation).AutoInclude();

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
            modelBuilder.Entity<DrziUsemestru>().Navigation(d => d.IdPredmetNavigation).AutoInclude();
            modelBuilder.Entity<DrziUsemestru>().Navigation(d => d.IdProfesorNavigation).AutoInclude();
            modelBuilder.Entity<DrziUsemestru>().Navigation(d => d.IdSemestarNavigation).AutoInclude();

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.HasKey(e => e.IdPredmet).HasName("PK__Predmet__2C2B78975DFCD7EE");
            });
            //modelBuilder.Entity<Predmet>().Navigation(p => p.DrziUsemestrus).AutoInclude();

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__E4BBA604E614A306");
            });
            //modelBuilder.Entity<Profesor>().Navigation(p => p.DrziUsemestrus).AutoInclude();

            modelBuilder.Entity<Semestar>(entity =>
            {
                entity.HasKey(e => e.IdSemestar).HasName("PK__Semestar__C6BF30205996DFC2");

                entity.Property(e => e.SkolskaGodina).HasDefaultValueSql("('2023/2024')");
            });
            //modelBuilder.Entity<Semestar>().Navigation(s => s.DrziUsemestrus).AutoInclude();

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent).HasName("PK__Student__35B1F88A3B5EF8CC");
            });
            //modelBuilder.Entity<Student>().Navigation(s => s.Beleskas).AutoInclude();

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.IdTag).HasName("PK__Tag__020FEDB8FFEE4643");
            });
            //modelBuilder.Entity<Tag>().Navigation(t => t.TagBeleskas).AutoInclude();

            modelBuilder.Entity<TagBeleska>(entity =>
            {
                entity.HasKey(e => e.IdTagBeleska).HasName("PK__TagBeles__BFDC4DCA83D6F26A");

                entity.HasOne(d => d.IdBeleskaNavigation).WithMany(p => p.TagBeleskas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TagBeleska_Beleska");

                entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.TagBeleskas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TagBeleska_Tag");
            });
            modelBuilder.Entity<TagBeleska>().Navigation(t => t.IdTagNavigation).AutoInclude();
            //modelBuilder.Entity<TagBeleska>().Navigation(t => t.IdBeleskaNavigation).AutoInclude();
        }

        public Cas? GetCasWithRelatedEntities(int id)
        {
            return Cas
                .Include(c => c.IdDrziNavigation)
                .ThenInclude(d => d.IdProfesorNavigation)
                .Include(c => c.IdDrziNavigation)
                .ThenInclude(d => d.IdSemestarNavigation)
                .Include(c => c.IdDrziNavigation)
                .ThenInclude(d => d.IdPredmetNavigation)
                .FirstOrDefault(c => c.IdCas == id);
        }

        public DrziUsemestru? GetDrziUsemestruWithRelatedEntities(int id)
        {
            return DrziUsemestru
                .Include(d => d.IdPredmetNavigation)
                .Include(d => d.IdProfesorNavigation)
                .Include(d => d.IdSemestarNavigation)
                .FirstOrDefault(d => d.IdDrzi == id);
        }


        public Student? GetStudentWithRelatedEntities(int id)
        {
            return Student
                .Include(s => s.Beleskas)
                .FirstOrDefault(s => s.IdStudent == id);
        }

        public Semestar? GetSemestarWithRelatedEntities(int id)
        {
            return Semestar
                .Include(s => s.DrziUsemestrus)
                .FirstOrDefault(s => s.IdSemestar == id);
        }

        public Profesor? GetProfesorWithRelatedEntities(int id)
        {
            return Profesor
                .Include(p => p.DrziUsemestrus)
                .FirstOrDefault(p => p.IdProfesor == id);
        }

        public Predmet? GetPredmetWithRelatedEntities(int id)
        {
            return Predmet
                .Include(p => p.DrziUsemestrus)
                .FirstOrDefault(p => p.IdPredmet == id);
        }

        public Beleska? GetBeleskaWithRelatedEntities(int id)
        {
            return Beleska
                .Include(b => b.IdCasNavigation)
                .Include(b => b.IdStudentNavigation)
                .Include(b => b.TagBeleskas)
                .ThenInclude(tb => tb.IdTagNavigation)
                .FirstOrDefault(b => b.IdBeleska == id);
        }

        public Tag? GetTagWithRelatedEntities(int id)
        {
            return Tag
                .Include(t => t.TagBeleskas)
                .FirstOrDefault(t => t.IdTag == id);
        }

        public TagBeleska? GetTagBeleskaWithRelatedEntities(int id)
        {
            return TagBeleska
                .Include(tb => tb.IdBeleskaNavigation)
                .Include(tb => tb.IdTagNavigation)
                .FirstOrDefault(tb => tb.IdTagBeleska == id);
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base(dateOnly =>
                    dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }
}
