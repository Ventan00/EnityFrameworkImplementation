using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab08.Configurations
{
    public class DoctorEFConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor)
                .HasName("Doctor_pk");

            builder.Property(e => e.IdDoctor).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

            var doctors = new List<Doctor>();
            doctors.Add(new Doctor{IdDoctor = 1, FirstName = "Xray",LastName = "Reyx",Email = "a@b.pl"});
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Whisky", LastName = "Skywi", Email = "c@d.pl" });
            doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Yankee", LastName = "Enekey", Email = "e@f.pl" });
            doctors.Add(new Doctor { IdDoctor = 4, FirstName = "Zulu", LastName = "Luzu", Email = "g@h.tv" });

            builder.HasData(doctors);

        }
    }
}
