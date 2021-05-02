using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab08.Configurations
{
    public class PrescriptionEFConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription)
                .HasName("Prescription_pk");

            builder.Property(e => e.IdPrescription).UseIdentityColumn();

            builder.Property(e => e.Date).IsRequired();

            builder.Property(e => e.IdDoctor).IsRequired();

            builder.Property(e => e.IdPatient).IsRequired();


            builder.HasOne(d => d.IdDoctorNavigation)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Doctor_Prescription");

            builder.HasOne(d => d.IdPatientNavigation)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Patient_Prescription");

            var prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription(){IdPrescription = 1,Date = DateTime.Today,DueDate = DateTime.Today.AddDays(10),IdDoctor = 1,IdPatient = 1});
            prescriptions.Add(new Prescription() { IdPrescription = 2, Date = DateTime.Today.AddDays(-12), DueDate = DateTime.Today, IdDoctor = 1, IdPatient = 2 });
            prescriptions.Add(new Prescription() { IdPrescription = 3, Date = DateTime.Today, DueDate = DateTime.Today.AddDays(120), IdDoctor = 3, IdPatient = 4 });
            prescriptions.Add(new Prescription() { IdPrescription = 4, Date = DateTime.Today.AddDays(-50), DueDate = DateTime.Today.AddDays(3), IdDoctor = 2, IdPatient = 3 });

            builder.HasData(prescriptions);

        }
    }
}
