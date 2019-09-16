using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Appointment
    {
        public string Id { get; set; }
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
