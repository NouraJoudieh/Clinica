using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Messages
    {
        public string Id { get; set; }
        public string ClinicaUserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public ClinicaUser ClinicaUser { get; set; }


    }
}
