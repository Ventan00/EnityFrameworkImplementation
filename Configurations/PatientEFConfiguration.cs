using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab08.Configurations
{
    public class PatientEFConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient)
                .HasName("Patient_pk");

            builder.Property(e => e.IdPatient).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Birthdate).IsRequired();

            var patients = new List<Patient>();

            patients.Add(new Patient {Birthdate = DateTime.Today, FirstName = "Adam", IdPatient = 1, LastName = "Dadam"});
            patients.Add(new Patient { Birthdate = (DateTime.Today.AddDays(-1)), FirstName = "Bartosz", IdPatient = 2, LastName = "Szabort" });
            patients.Add(new Patient { Birthdate = (DateTime.Today.AddDays(-2)), FirstName = "Celestyn", IdPatient = 3, LastName = "Nyseltyn" });
            patients.Add(new Patient { Birthdate = (DateTime.Today.AddDays(-3)), FirstName = "Delimer", IdPatient = 4, LastName = "Remiled" });

            builder.HasData(patients);

        }
    }
}
