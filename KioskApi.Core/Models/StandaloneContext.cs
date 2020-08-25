using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KioskApi.Core.Models
{
    public partial class StandaloneContext : DbContext
    {
        public StandaloneContext()
        {
        }

        public StandaloneContext(DbContextOptions<StandaloneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cnte> Cnte { get; set; }
        public virtual DbSet<Empe> Empe { get; set; }
        public virtual DbSet<Empr> Empr { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Remittance> Remittance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=NISSQLSRV-01;Database=Standalone;user=document;password=as400_s10479fr;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cnte>(entity =>
            {
                entity.ToTable("CNTE");

                entity.Property(e => e.Contribution).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Earnings).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Frequence)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Interest).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Penalties).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Week1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week5)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empe>(entity =>
            {
                entity.ToTable("EMPE");

                entity.Property(e => e.Address)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DateOb)
                    .HasColumnName("DateOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Email2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Parish)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empr>(entity =>
            {
                entity.ToTable("EMPR");

                entity.Property(e => e.BusinessAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessTown)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BusinesssParish)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Email2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RealAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RealName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RealParish)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RealPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RealTown)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rates>(entity =>
            {
                entity.ToTable("RATES");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Remittance>(entity =>
            {
                entity.ToTable("REMITTANCE");

                entity.Property(e => e.Contribution).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Earnings).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Frequence)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Interest).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Penalties).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.Week1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Week5)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
