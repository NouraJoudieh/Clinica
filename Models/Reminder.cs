using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Reminder
    {
        private string _priority { get; set; }
        public string Id { get; set; }
        [ForeignKey(nameof(ClinicaUser))]
        public string ClinicaUserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string Priority
        {
            /**
             * (c) 2019 - Clinica
             * @Author: Hamza Jadeed
             * @Description: Changing the color of the card header depending on the priority
             */
            get => _priority.Replace("urgent", "danger").Replace("important", "warning").Replace("normal", "success");
            set => _priority = value.ToLower();
        }
        public string Title { get; set; }
        public ClinicaUser ClinicaUser { get; set; }
    }
}
