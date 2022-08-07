using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PharmacyMediSupplyRepository.Models
{
    public partial class PharmacySupplyContext : DbContext
    {
        public PharmacySupplyContext()
        {
        }

        public PharmacySupplyContext(DbContextOptions<PharmacySupplyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Demand> Demands { get; set; }
        public virtual DbSet<MedicineStock> MedicineStocks { get; set; }
        public virtual DbSet<MedicineSupply> MedicineSupplies { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning: 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=PharmacySupply; integrated security=true");
#pragma warning restore CS1030 // #warning: 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Demand>(entity =>
            {
                entity.ToTable("Demand");

                entity.Property(e => e.DemandId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MedicineId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Demand__Medicine__25869641");
            });

            modelBuilder.Entity<MedicineStock>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__Medicine__4F212890C70F3DA9");

                entity.ToTable("MedicineStock");

                entity.Property(e => e.MedicineId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicineSupply>(entity =>
            {
                entity.ToTable("MedicineSupply");

                entity.Property(e => e.MedicineSupplyId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DemandId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PharmacyId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.MedicineSupplies)
                    .HasForeignKey(d => d.DemandId)
                    .HasConstraintName("FK__MedicineS__Deman__2B3F6F97");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.MedicineSupplies)
                    .HasForeignKey(d => d.PharmacyId)
                    .HasConstraintName("FK__MedicineS__Pharm__2A4B4B5E");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.ToTable("Pharmacy");

                entity.Property(e => e.PharmacyId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PharmacyName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
