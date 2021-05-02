using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab08.Models.DTO
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public dynamic Doctor { get; set; }
        public dynamic Patient { get; set; }
        public dynamic Medicaments { get; set; }
    }
}
