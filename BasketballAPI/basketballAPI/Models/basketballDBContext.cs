using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace basketballAPI.Models
{
    public partial class BASKETBALLDBContext : DbContext
    {
        public BASKETBALLDBContext()
        {
        }

        public BASKETBALLDBContext(DbContextOptions<BASKETBALLDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fixture> Fixtures { get; set; }
        public virtual DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BASKETBALLDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fixture>(entity =>
            {
                entity.ToTable("FIXTURE");

                entity.Property(e => e.Fixtureid)
                    .ValueGeneratedNever()
                    .HasColumnName("FIXTUREID");

                entity.Property(e => e.Fixturecost).HasColumnName("FIXTURECOST");

                entity.Property(e => e.Fixturedate)
                    .HasColumnType("datetime")
                    .HasColumnName("FIXTUREDATE");

                entity.Property(e => e.Fixturemembername)
                    .HasMaxLength(50)
                    .HasColumnName("FIXTUREMEMBERNAME");

                entity.Property(e => e.Fixturevenue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIXTUREVENUE");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("MEMBER");

                entity.Property(e => e.Memberid)
                    .HasMaxLength(50)
                    .HasColumnName("MEMBERID");

                entity.Property(e => e.Membername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MEMBERNAME");

                entity.Property(e => e.Memberpassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MEMBERPASSWORD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
