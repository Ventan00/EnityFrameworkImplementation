using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab08.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual IEnumerable<Prescription> Prescriptions { get; set; }
    }
}
