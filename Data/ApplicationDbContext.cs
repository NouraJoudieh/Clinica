using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinica.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Clinica.Models.Doctor> Doctor { get; set; }
        public DbSet<Clinica.Models.Assistant> Assistant { get; set; }
        public DbSet<Clinica.Models.InsuranceCompany> InsuranceCompany { get; set; }
        public DbSet<Clinica.Models.Patient> Patient { get; set; }
        public DbSet<Clinica.Models.Appointment> Appointment { get; set; }
        public DbSet<Clinica.Models.Consultation> Consultation { get; set; }
        public DbSet<Clinica.Models.Messages> Messages { get; set; }
        public DbSet<Clinica.Models.Reminder> Reminder { get; set; }
        public DbSet<Clinica.Models.Reports> Reports { get; set; }
    }
}
