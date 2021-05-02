using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab08.Repositories.Interfaces;

namespace lab08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerscriptionsController : ControllerBase
    {
        private readonly IDbRepository _dbRepository;

        public PerscriptionsController(IDbRepository repository)
        {
            _dbRepository = repository;
        }

        [HttpGet("{idPrescription}")] 
        public async Task<IActionResult> GetPrescription([FromRoute] int idPrescription)
        {
            return Ok(await _dbRepository.GetPrescription(idPrescription));
        }
    }
}
