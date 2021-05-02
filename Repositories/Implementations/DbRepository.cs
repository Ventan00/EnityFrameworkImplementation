using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models;
using lab08.Models.DTO;
using lab08.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab08.Repositories.Implementations
{
    public class DbRepository : IDbRepository
    {
        private readonly MedicamentContext _context;

        public DbRepository(MedicamentContext context)
        {
            _context = context;
        }

        public async Task<ICollection<DoctorDTO>> GetDoctorsAsync()
        {
            return await _context.Doctor.Select(doctor => new DoctorDTO()
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                IdDoctor = doctor.IdDoctor
            }).ToListAsync();
        }

        public async Task<bool> AddDoctorAsync(DoctorDTO doctor)
        {
            await _context.Doctor.AddAsync(new Doctor()
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDoctorAsync(DoctorDTO doctor)
        {
            var doctorFromDb = await _context.Doctor.SingleOrDefaultAsync(d => d.IdDoctor == doctor.IdDoctor);
            if (doctorFromDb == null) 
            {
                return false;
            }

            doctorFromDb.FirstName = doctor.FirstName;
            doctorFromDb.LastName = doctor.LastName;
            doctorFromDb.Email = doctor.Email;

            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteDoctorAsync(DoctorDTO doctor)
        {
            var doctorFromDb = await _context.Doctor.SingleOrDefaultAsync(d => d.IdDoctor == doctor.IdDoctor);
            if (doctorFromDb == null)
                return false;
            _context.Remove(doctorFromDb);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PrescriptionDTO> GetPrescription(int IdPrescription)
        {
            return await _context.Prescription
                .Include(p => p.IdPatientNavigation)
                .Include(p => p.IdDoctorNavigation)
                .Include(p => p.PrescriptionMedicaments)
                .ThenInclude(pm => pm.IdMedicamentNavigation)
                .Where(p => p.IdPrescription== IdPrescription)
                .Select(p => new PrescriptionDTO()
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Patient = new
                    {
                        IdPatient = p.IdPatientNavigation.IdPatient,
                        FirstName = p.IdPatientNavigation.FirstName,
                        LastName = p.IdPatientNavigation.LastName,
                        BirthDate = p.IdPatientNavigation.Birthdate
                    },
                    Doctor = new
                    {
                        IdDoctor = p.IdDoctorNavigation.IdDoctor,
                        FirstName = p.IdDoctorNavigation.FirstName,
                        LastName = p.IdDoctorNavigation.LastName,
                        Email = p.IdDoctorNavigation.Email,
                    },
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new
                    {
                        IdMedicament = pm.IdMedicamentNavigation.IdMedicament,
                        Name = pm.IdMedicamentNavigation.Name,
                        Description = pm.IdMedicamentNavigation.Description,
                        Dose = pm.Dose,
                        Details = pm.Details
                    })
                }).SingleOrDefaultAsync();
        }

    }
}
