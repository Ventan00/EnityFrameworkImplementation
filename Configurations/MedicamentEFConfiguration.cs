using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab08.Configurations
{
    public class MedicamentEFConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament)
                .HasName("Medicament_pk");

            builder.Property(e => e.IdMedicament).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Type).HasMaxLength(100).IsRequired();

            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament{Description = "nie zabija a leczy",IdMedicament = 1,Name="Zioło",Type = "Trawa"});
            medicaments.Add(new Medicament { Description = "Długoterminowy efekt", IdMedicament = 2, Name = "Chlor", Type = "Chemia" });
            medicaments.Add(new Medicament { Description = "Jest smaczniutka", IdMedicament = 3, Name = "Sencha", Type = "Trawa" });
            medicaments.Add(new Medicament { Description = "Niszczy meterię organiczną", IdMedicament = 4, Name = "Pirania", Type = "Chemia" });

            builder.HasData(medicaments);

        }
    }
}
