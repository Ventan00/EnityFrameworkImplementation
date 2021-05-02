﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab08.Models;

namespace lab08.Migrations
{
    [DbContext(typeof(MedicamentContext))]
    [Migration("20210502183329_FirstAdd")]
    partial class FirstAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab08.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_pk");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "a@b.pl",
                            FirstName = "Xray",
                            LastName = "Reyx"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "c@d.pl",
                            FirstName = "Whisky",
                            LastName = "Skywi"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "e@f.pl",
                            FirstName = "Yankee",
                            LastName = "Enekey"
                        },
                        new
                        {
                            IdDoctor = 4,
                            Email = "g@h.tv",
                            FirstName = "Zulu",
                            LastName = "Luzu"
                        });
                });

            modelBuilder.Entity("lab08.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("Medicament_pk");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "nie zabija a leczy",
                            Name = "Zioło",
                            Type = "Trawa"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Długoterminowy efekt",
                            Name = "Chlor",
                            Type = "Chemia"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Jest smaczniutka",
                            Name = "Sencha",
                            Type = "Trawa"
                        },
                        new
                        {
                            IdMedicament = 4,
                            Description = "Niszczy meterię organiczną",
                            Name = "Pirania",
                            Type = "Chemia"
                        });
                });

            modelBuilder.Entity("lab08.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("Patient_pk");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Adam",
                            LastName = "Dadam"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Bartosz",
                            LastName = "Szabort"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Celestyn",
                            LastName = "Nyseltyn"
                        },
                        new
                        {
                            IdPatient = 4,
                            Birthdate = new DateTime(2021, 4, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Delimer",
                            LastName = "Remiled"
                        });
                });

            modelBuilder.Entity("lab08.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_pk");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            IdDoctor = 1,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            IdDoctor = 3,
                            IdPatient = 4
                        },
                        new
                        {
                            IdPrescription = 4,
                            Date = new DateTime(2021, 3, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            IdDoctor = 2,
                            IdPatient = 3
                        });
                });

            modelBuilder.Entity("lab08.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament");

                    b.HasIndex("IdMedicament");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 1,
                            Details = "Uważaj!"
                        },
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 2,
                            Details = "Zjedz!",
                            Dose = 10
                        },
                        new
                        {
                            IdPrescription = 2,
                            IdMedicament = 3,
                            Details = "Jakies dane!",
                            Dose = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            IdMedicament = 4,
                            Details = "Kolorowe!!!"
                        });
                });

            modelBuilder.Entity("lab08.Models.Prescription", b =>
                {
                    b.HasOne("lab08.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("Doctor_Prescription")
                        .IsRequired();

                    b.HasOne("lab08.Models.Patient", "IdPatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .HasConstraintName("Patient_Prescription")
                        .IsRequired();

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("lab08.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("lab08.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .HasConstraintName("Medicament_PrescriptionMedicament")
                        .IsRequired();

                    b.HasOne("lab08.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .HasConstraintName("Prescription_PrescriptionMedicament")
                        .IsRequired();

                    b.Navigation("IdMedicamentNavigation");

                    b.Navigation("IdPrescriptionNavigation");
                });

            modelBuilder.Entity("lab08.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("lab08.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("lab08.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("lab08.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}