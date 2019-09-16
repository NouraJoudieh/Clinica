using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Consultation
    {
        public string Id { get; set; }
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public int Cost { get; set; }
        public string Treatment { get; set; }
        public string InsuranceConfirmation { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }




    }
}
