using Microsoft.EntityFrameworkCore;

namespace SportsAgents.Models
{
    public partial class SportsAgentsContext : DbContext
    {
        public SportsAgentsContext()
        {
        }

        public SportsAgentsContext(DbContextOptions<SportsAgentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=SportsAgentsDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisciplineName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(40);

                entity.Property(e => e.UserLogin).HasMaxLength(128);

                /*
                entity.HasOne(d => d.UserLoginNavigation)
                    .WithMany(p => p.Athletes)
                    .HasForeignKey(d => d.UserLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Athletes__UserLo__74AE54BC");
                */
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PK__Users__5E55825A301E8601");

                entity.Property(e => e.Login).HasMaxLength(128);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMail");

                entity.Property(e => e.FullName).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
