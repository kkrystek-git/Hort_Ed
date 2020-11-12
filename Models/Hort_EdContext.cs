using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hort_Ed.Models
{
    public partial class Hort_EdContext : DbContext
    {
        public Hort_EdContext()
        {
        }

        public Hort_EdContext(DbContextOptions<Hort_EdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Enrollments> Enrollments { get; set; }
        public virtual DbSet<Kits> Kits { get; set; }
        public virtual DbSet<Seminars> Seminars { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KRYSTEKPC;Database=Hort_Ed;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Enrollments>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId);

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.KitSelection).HasColumnName("KitSelection");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SeminarId)
                    .HasColumnName("SeminarID")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Enrollmen__Custo__44FF419A");

                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.KitSelection)
                    .HasConstraintName("FK__Enrollmen__KitID__46E78A0C");

                entity.HasOne(d => d.Seminar)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.SeminarId)
                    .HasConstraintName("FK__Enrollmen__Semin__45F365D3");
            });

            modelBuilder.Entity<Kits>(entity =>
            {
                entity.HasKey(e => e.KitId);

                entity.Property(e => e.KitId)
                    .HasColumnName("KitID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.KitName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Seminars>(entity =>
            {
                entity.HasKey(e => e.SeminarId);

                entity.Property(e => e.SeminarId)
                    .HasColumnName("SeminarID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.DeliveryType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Details).HasMaxLength(500);

                entity.Property(e => e.Seasonal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SeminarTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaterialKit1Navigation)
                    .WithMany(p => p.SeminarsMaterialKit1Navigation)
                    .HasForeignKey(d => d.MaterialKit1)
                    .HasConstraintName("FK__Seminars__Materi__3B75D760");

                entity.HasOne(d => d.MaterialKit2Navigation)
                    .WithMany(p => p.SeminarsMaterialKit2Navigation)
                    .HasForeignKey(d => d.MaterialKit2)
                    .HasConstraintName("FK__Seminars__Materi__3C69FB99");

                entity.HasOne(d => d.MaterialKit3Navigation)
                    .WithMany(p => p.SeminarsMaterialKit3Navigation)
                    .HasForeignKey(d => d.MaterialKit3)
                    .HasConstraintName("FK__Seminars__Materi__3D5E1FD2");

                entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChangeAction)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.KitSelection).HasColumnName("KitSelection");

                entity.Property(e => e.SeminarId)
                    .HasColumnName("SeminarID")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__Custo__403A8C7D");

                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.KitSelection)
                    .HasConstraintName("FK__Transacti__KitID__4222D4EF");

                entity.HasOne(d => d.Seminar)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SeminarId)
                    .HasConstraintName("FK__Transacti__Semin__412EB0B6");
            });
        }
    }
}
