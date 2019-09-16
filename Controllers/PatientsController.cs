using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Clinica.Controllers
{
    
    public class PatientsController : Controller
    {
        public Users user;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ClinicaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<PatientsController> _logger;
       

        public PatientsController(ApplicationDbContext context, 
            ILogger<PatientsController> logger, 
            UserManager<ClinicaUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        [Authorize(Roles = "Doctor,Assistant")]
        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Patient
                .Include(p => p.ClinicaUser)
                .Include(p => p.InsuranceCompany)
                    .ThenInclude(u=>u.ClinicaUser);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Patient")]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult ViewConsultations() {
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cons = _context.Consultation
                        .Include(u => u.Patient)
                            .ThenInclude(k => k.ClinicaUser)
                        .Include(d => d.Doctor)
                            .ThenInclude(m =>m.ClinicaUser)
                        .Where(i => i.PatientId.Contains(id));
            return View(cons);
        }
        [Authorize(Roles = "Doctor,Assistant")]

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.ClinicaUser)
                .Include(p => p.InsuranceCompany)
                    .ThenInclude(u => u.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
        [Authorize(Roles = "Doctor,Assistant")]
        //// GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id");
            ViewData["InCId"] = new SelectList(_context.InsuranceCompany, "Id", "Id");
            return View();
        }

        //// POST: Patients/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,InsuranceCompanyId,Gender,Birthdate,Address,BloodType,Picture")] Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(patient);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", patient.Id);
        //    ViewData["InsuranceCompanyId"] = new SelectList(_context.InsuranceCompany, "Id", "Id", patient.InsuranceCompanyId);
        //    return View(patient);
        //}

        // GET: Patients/Edit/5
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            var clinicaUser = await _userManager.FindByIdAsync(patient.Id);
            var user = new Users
            {
                Id = clinicaUser.Id,
                UserName = clinicaUser.UserName,
                Email = clinicaUser.Email,
                Phonenb = clinicaUser.PhoneNumber,
                FirstName = clinicaUser.FirstName,
                MiddleName = clinicaUser.MiddleName,
                LastName =clinicaUser.LastName,
                Mobile = clinicaUser.Mobile,
                Gender = patient.Gender,
                Address = patient.Address,
                Birthdate = patient.Birthdate,
                BloodType = patient.BloodType,
                InsuranceCompany = patient.InsuranceCompany
            };
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", patient.Id);
            ViewData["InsuranceCompanyId"] = new SelectList(_context.InsuranceCompany, "Id", "Id", patient.InsuranceCompanyId);
            return View(user);
        }
        [HttpPost]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Create(Users user)
        {
            ClinicaUser cuser =
                new ClinicaUser
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PhoneNumber = user.Phonenb,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Mobile = user.Mobile
                };
            string role = "Patient";
            bool result = await _roleManager.RoleExistsAsync(role);
            await _userManager.CreateAsync(cuser, user.Password);
            if (!result)
                await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(cuser, role);
            var ICUser = _context.Users.Where(u => u.UserName.Contains(user.InsuranceCompanyId)).FirstOrDefault();
            var IC = _context.InsuranceCompany.Find(ICUser.Id);
            await _context.Patient.AddAsync(
                new Patient
                {
                    Gender = user.Gender,
                    Birthdate = user.Birthdate,
                    Address = user.Address,
                    BloodType = user.BloodType,
                    Picture = user.Picture,
                    InsuranceCompanyId = ICUser.Id,
                    InsuranceCompany=IC,
                    ClinicaUser = cuser
                });
            await _context.SaveChangesAsync();
            if (User.IsInRole("Doctor"))
            {
                return Redirect("/Doctors/Dashboard");
            }
            else
                return Redirect("/Assistants/Dashboard");
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Email,FirstName,MiddleName,LastName,Phonenb,Mobile,InsuranceCompanyId,Gender,Birthdate,Address,BloodType")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var insurance = _context.Users.Where(u => u.UserName.Contains(users.InsuranceCompanyId)).FirstOrDefault();
                    var company = await _context.InsuranceCompany.FindAsync(insurance.Id);
                    users.InsuranceCompany = company;
                    var patient = await _context.Patient.FirstOrDefaultAsync(u => u.Id == users.Id);
                    var clinicaUser = await _userManager.FindByIdAsync(users.Id);
                    patient.Gender = users.Gender;
                    patient.Birthdate = users.Birthdate;
                    patient.BloodType = users.BloodType;
                    patient.Address = users.Address;
                    clinicaUser.FirstName = users.FirstName;
                    clinicaUser.MiddleName = users.MiddleName;
                    clinicaUser.LastName = users.LastName;
                    clinicaUser.Mobile = users.Mobile;
                    clinicaUser.PhoneNumber = users.Phonenb;
                    clinicaUser.UserName = users.UserName;
                    clinicaUser.Email = users.Email;
                    _context.Update(patient);
                    await _userManager.UpdateAsync(clinicaUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (User.IsInRole("Doctor"))
                {
                    return Redirect("/Doctors/Dashboard");
                }
                else
                    return Redirect("/Assistants/Dashboard");
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", user.Id);
            ViewData["InsuranceCompanyId"] = new SelectList(_context.InsuranceCompany, "Id", "Id", user.InsuranceCompanyId);
            return View(user);
        }

        // GET: Patients/Delete/5
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.ClinicaUser)
                .Include(p => p.InsuranceCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patient = await _context.Patient
                .Include(c => c.ClinicaUser)
                .FirstOrDefaultAsync(p => p.Id == id);
            var iur = await _context.UserRoles.FirstOrDefaultAsync(p => p.UserId == patient.Id);
            _context.UserRoles.Remove(iur);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Doctor"))
            {
                return Redirect("/Doctors/Dashboard");
            }
            else
                return Redirect("/Assistants/Dashboard");
        }

        private bool PatientExists(string id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }

        public IActionResult ViewPatients() {
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var assistant = _context.Assistant.Include(a=>a.Doctor).Where(a => a.Id.Contains(id)).FirstOrDefault(); // logged in assistant
            var doc = assistant.Doctor;
            List<Clinica.Models.Patient> patient = new List<Clinica.Models.Patient>();
            var app = _context.Appointment.Include(a => a.Patient).ThenInclude(p => p.ClinicaUser).Where(a => a.DoctorId.Contains(doc.Id)).ToList();
            foreach (var item in app)
            {
                patient.Add(item.Patient);
            }
            return View(patient);

        }
    }
}
