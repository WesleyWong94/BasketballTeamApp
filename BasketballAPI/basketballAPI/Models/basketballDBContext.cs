using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace basketballAPI.Models
{
    public partial class basketballDBContext : DbContext
    {
        public basketballDBContext()
        {
        }

        public basketballDBContext(DbContextOptions<basketballDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fixture> Fixtures { get; set; }
        public virtual DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=basketballDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fixture>(entity =>
            {
                entity.HasKey(e => e.Fixturedate)
                    .HasName("PK_FIXTUREDATE");

                entity.ToTable("FIXTURE");

                entity.Property(e => e.Fixturedate)
                    .HasColumnType("datetime")
                    .HasColumnName("FIXTUREDATE");

                entity.Property(e => e.Fixturename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIXTURENAME");

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
