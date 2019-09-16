using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Users
    {
        //identity
        public string Id { get; set; }
        [Display(Name = "Username")]
        [StringLength(50)]
        public string UserName { get; set; }
        public ClinicaUser ClinicaUser { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name=" Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phonenb { get; set; }
        //clinicaUser
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        //Doctor
        //Assistant note add a select optiont to the view having all doctors available
        [Display(Name ="Doctor Username")]
        public string DoctorId { get; set; }
        [StringLength(6)]
        public string Gender { get; set; }
        [StringLength(40)]
        public string Speciality { get; set; }
        [DataType(DataType.Time)]
        [Display(Name ="Available From")]
        public DateTime AvailableFrom { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Available To")]
        public DateTime AvailableTo { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(300)]
        public string About { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [StringLength(3)]
        [Display(Name ="Blood Type")]
        public string BloodType { get; set; }

        public string Picture { get; set; }
        [Display(Name ="Insurance Company Username")]
        public string InsuranceCompanyId { get; set; }
        //address with IC
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }

    }
}
