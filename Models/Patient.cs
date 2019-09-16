using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Models
{
    public class Patient
    {
        [Key]
        [ForeignKey(nameof(ClinicaUser))]
        public string Id { get; set; }
        [ForeignKey(nameof(InsuranceCompany))]
        public string InsuranceCompanyId { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Picture { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public ClinicaUser ClinicaUser { get; set; }
    }
}
