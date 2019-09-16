using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Assistant
    {
        [Key]
        [ForeignKey(nameof(ClinicaUser))]
        public string Id { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public string Gender { get; set; }
        public Doctor Doctor { get; set; }
        public ClinicaUser ClinicaUser { get; set; }
    }
}
