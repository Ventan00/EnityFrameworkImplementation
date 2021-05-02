using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Models.DTO;
using lab08.Repositories.Interfaces;

namespace lab08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbRepository _dbRepository;

        public DoctorsController(IDbRepository repository)
        {
            _dbRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctor()
        {
            return Ok(await _dbRepository.GetDoctorsAsync()) ;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO doctor)
        {
            return await _dbRepository.AddDoctorAsync(doctor) ? Ok() : BadRequest("Nie poprawny doktor");
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> UpdateDoctor([FromBody] DoctorDTO doctor, [FromRoute] int idDoctor)
        {
            return  (doctor.IdDoctor == idDoctor && await _dbRepository.UpdateDoctorAsync(doctor)) ? Ok() : BadRequest("Nie poprawne dane");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor([FromBody] DoctorDTO doctor)
        {
            return await _dbRepository.DeleteDoctorAsync(doctor) ? Ok() : BadRequest("Nie poprawne dane");
        }
    }
}
