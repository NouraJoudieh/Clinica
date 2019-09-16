
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Models
{
    public class InsuranceCompany
    {
        [Key]
        [ForeignKey(nameof(ClinicaUser))]
        public string Id { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public ClinicaUser ClinicaUser { get; set; }
    }
}
