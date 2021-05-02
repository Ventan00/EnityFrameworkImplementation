using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab08.Configurations
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");

            builder.HasKey(e => new { e.IdPrescription, e.IdMedicament });

            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Dose).IsRequired(false);

            builder.Property(e => e.IdMedicament).IsRequired();

            builder.Property(e => e.IdPrescription).IsRequired();

            builder.HasOne(d => d.IdMedicamentNavigation)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_PrescriptionMedicament");

            builder.HasOne(d => d.IdPrescriptionNavigation)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_PrescriptionMedicament");

            var prescriptionMedicaments = new List<PrescriptionMedicament>();
            prescriptionMedicaments.Add(new PrescriptionMedicament{IdMedicament = 1,IdPrescription = 1,Details = "Uważaj!"});
            prescriptionMedicaments.Add(new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 1, Details = "Zjedz!",Dose = 10});
            prescriptionMedicaments.Add(new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 2, Details = "Jakies dane!", Dose = 2 });
            prescriptionMedicaments.Add(new PrescriptionMedicament { IdMedicament = 4, IdPrescription = 3, Details = "Kolorowe!!!" });
            builder.HasData(prescriptionMedicaments);

        }
    }
}
