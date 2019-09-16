using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Reports
    {

        public string Id { get; set; }
        [ForeignKey(nameof(Consultation))]
        public string ConsultationId { get; set; }
        [ForeignKey(nameof(InsuranceCompany))]
        public string InsuranceCompanyId { get; set; }
        public DateTime Date { get; set; }

        public Consultation Consultation { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
    }
}
