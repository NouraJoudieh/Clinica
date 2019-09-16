using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Doctor
    {
        [Key]
        [ForeignKey(nameof(ClinicaUser))]
        public string Id { get; set; }
        public string Gender { get; set; }
        public string Speciality { get; set; }
        [DataType(DataType.Time)]
        public DateTime AvailableFrom { get; set; }
        [DataType(DataType.Time)]
        public DateTime AvailableTo { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public ClinicaUser ClinicaUser { get; set; }
    }
}
