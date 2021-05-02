using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models.DTO;

namespace lab08.Repositories.Interfaces
{
    public interface IDbRepository
    {
        Task<ICollection<DoctorDTO>> GetDoctorsAsync();
        Task<bool> AddDoctorAsync(DoctorDTO doctor);
        Task<bool> UpdateDoctorAsync(DoctorDTO doctor);
        Task<bool> DeleteDoctorAsync(DoctorDTO doctor);
        Task<PrescriptionDTO> GetPrescription(int IdPrescription);
    }
}
