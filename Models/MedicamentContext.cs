using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Configurations;
using Microsoft.EntityFrameworkCore;

namespace lab08.Models
{
    public class MedicamentContext : DbContext
    {
        public MedicamentContext() { }

        public MedicamentContext(DbContextOptions<MedicamentContext> options) : base(options)
        {

        }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicamentEFConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEFConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorEFConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEFConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");

                entity.HasKey(e => new {e.IdPrescription, e.IdMedicament});

                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.Property(e => e.IdMedicament).IsRequired();

                entity.Property(e => e.IdPrescription).IsRequired();

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Medicament_PrescriptionMedicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_PrescriptionMedicament");
            });
        }
    }
}
