
using System.Linq;
using System.Threading.Tasks;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clinica.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public Users user;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ClinicaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationDbContext context,
            UserManager<ClinicaUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AdminController> logger)  //ctor tab2*
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(user);
        }

        public async Task<IActionResult> AddDoc(Users user)
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
            string role = "Doctor";
            bool result = await _roleManager.RoleExistsAsync(role);
            await _userManager.CreateAsync(cuser, user.Password);
            if (!result) await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(cuser, role);
            await _context.Doctor.AddAsync(
                new Doctor
                {
                    Speciality = user.Speciality,
                    Gender = user.Gender,
                    About = user.About,
                    AvailableFrom = user.AvailableFrom,
                    AvailableTo = user.AvailableTo,
                    Address = user.Address,
                    ClinicaUser = cuser
                });
            await _context.SaveChangesAsync();
            return Redirect("/Admin");
        }

        public async Task<IActionResult> AddAssistant(Users user)
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
            string role = "Assistant";
            bool result = await _roleManager.RoleExistsAsync(role);
            await _userManager.CreateAsync(cuser, user.Password);
            if (!result)
                await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(cuser, role);
            //Username was displayed and saved in DoctorId in the razor file
            var doctorUser = _context.Users.Where(u => u.UserName.Contains(user.DoctorId)).FirstOrDefault();
            await _context.Assistant.AddAsync(
                new Assistant
                {
                    Gender = user.Gender,
                    DoctorId = doctorUser.Id,
                    ClinicaUser = cuser
                });
            await _context.SaveChangesAsync();
            return Redirect("/Admin");
        }
        public async Task<IActionResult> AddInsuranceCompany(Users user)
        {
            ClinicaUser cuser =
               new ClinicaUser
               {
                   Email = user.Email,
                   UserName = user.UserName,
                   PhoneNumber = user.Phonenb,
                   Mobile = user.Mobile
               };
            string role = "InsuranceCompany";
            bool result = await _roleManager.RoleExistsAsync(role);
            await _userManager.CreateAsync(cuser, user.Password);


            if (!result)
                await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(cuser, role);
            await _context.InsuranceCompany.AddAsync(
                new InsuranceCompany
                {
                    Address = user.Address,
                    Fax = user.Fax,
                    ClinicaUser = cuser
                });
            await _context.SaveChangesAsync();
            return Redirect("/Admin");
        }

        public async Task<IActionResult> _EditDoctor(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            var cuser = await _userManager.FindByIdAsync(id);
            var users = new Users
            {
                Id = id,
                DoctorId = id,
                Gender = doctor.Gender,
                Speciality = doctor.Speciality,
                AvailableFrom = doctor.AvailableFrom,
                AvailableTo = doctor.AvailableTo,
                Address = doctor.Address,
                About = doctor.About,
                UserName = cuser.UserName,
                FirstName = cuser.FirstName,
                MiddleName = cuser.MiddleName,
                LastName = cuser.LastName,
                Email = cuser.Email,
                Phonenb = cuser.PhoneNumber,
                Mobile = cuser.Mobile
            };
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", id);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditDoctor(string id, [Bind("Id,UserName,Email,Phonenb,FirstName,MiddleName,LastName,Mobile,Gender,Speciality,AvailableFrom,AvailableTo,Address,About")] Users users)
        {
            #region UpdateDoc
            var doc = await _context.Doctor.FindAsync(id);
            doc.Gender = users.Gender;
            doc.AvailableFrom = users.AvailableFrom;
            doc.AvailableTo = users.AvailableTo;
            doc.Address = users.Address;
            doc.About = users.About;
            doc.Speciality = users.Speciality;
            #endregion
            #region UpdateClinicaUser
            var clinicaUser = await _userManager.FindByIdAsync(id);
            clinicaUser.Email = users.Email;
            clinicaUser.FirstName = users.FirstName;
            clinicaUser.MiddleName = users.MiddleName;
            clinicaUser.LastName = users.LastName;
            clinicaUser.PhoneNumber = users.Phonenb;
            clinicaUser.Mobile = users.Mobile;
            clinicaUser.UserName = users.UserName;
            #endregion
            if (id != doc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doc);
                    await _userManager.UpdateAsync(clinicaUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", doc.Id);
            return View(user);
        }
        private bool DoctorExists(string id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }



        public async Task<IActionResult> _EditAssistant(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistant.FindAsync(id);
            var cuser = await _userManager.FindByIdAsync(id);
            // var doctorUser = _context.Users.Where(u => u.UserName.Contains(user.DoctorId)).FirstOrDefault();
            var users = new Users
            {
                Id = id,
                // DoctorId = doctorUser.Id,
                Gender = assistant.Gender,
                UserName = cuser.UserName,
                FirstName = cuser.FirstName,
                MiddleName = cuser.MiddleName,
                LastName = cuser.LastName,
                Email = cuser.Email,
                Phonenb = cuser.PhoneNumber,
            };
            if (assistant == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", id);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditAssistant(string id, [Bind("Id,UserName,Email,Phonenb,FirstName,MiddleName,LastName,Gender,DoctorId")] Users users)
        {
            _logger.LogInformation("Something: " + users.DoctorId);
            #region UpdateAssistant
            var assistant = await _context.Assistant.FindAsync(id);
            var doctor = _context.Users.Where(u => u.UserName.Contains(users.DoctorId)).FirstOrDefault();
            var doc = _context.Doctor.Where(d=>d.Id==doctor.Id).FirstOrDefault();
            assistant.Gender = users.Gender;
            assistant.DoctorId = doctor.Id;
            assistant.Doctor = doc;
            #endregion
            #region UpdateClinicaUser
            var clinicaUser = await _userManager.FindByIdAsync(id);
            clinicaUser.Email = users.Email;
            clinicaUser.FirstName = users.FirstName;
            clinicaUser.MiddleName = users.MiddleName;
            clinicaUser.LastName = users.LastName;
            clinicaUser.PhoneNumber = users.Phonenb;
            clinicaUser.UserName = users.UserName;
            #endregion
            if (id != assistant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistant);
                    await _userManager.UpdateAsync(clinicaUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(assistant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", assistant.Id);
            return View(user);
        }
       


        public async Task<IActionResult> _EditInsuranceCompany(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompany.FindAsync(id);
            var cuser = await _userManager.FindByIdAsync(id);
            // var doctorUser = _context.Users.Where(u => u.UserName.Contains(user.DoctorId)).FirstOrDefault();
            var users = new Users
            {
                Id = id,
                Address=insuranceCompany.Address,
                // DoctorId = doctorUser.Id,
                Fax = insuranceCompany.Fax,
                UserName = cuser.UserName,
                Email = cuser.Email,
                Phonenb = cuser.PhoneNumber,
            };
            if (insuranceCompany == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", id);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditInsuranceCompany(string id, [Bind("Id,UserName,Email,Phonenb,Address,Fax")] Users users)
        {
            _logger.LogInformation("Something: " + users.DoctorId);
            #region UpdateInsuranceCompany
            var insuranceCompany = await _context.InsuranceCompany.FindAsync(id);
            insuranceCompany.Fax = users.Fax;
            insuranceCompany.Address = users.Address;
            #endregion
            #region UpdateClinicaUser
            var clinicaUser = await _userManager.FindByIdAsync(id);
            clinicaUser.Email = users.Email;
            clinicaUser.PhoneNumber = users.Phonenb;
            clinicaUser.UserName = users.UserName;
            #endregion
            if (id != insuranceCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceCompany);
                    await _userManager.UpdateAsync(clinicaUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(insuranceCompany.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", insuranceCompany.Id);
            return View(user);
        }

        public async Task<IActionResult> DeleteReminder(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .Include(r => r.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // POST: Reminders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReminderConfirmed(string id)
        {
            var reminder = await _context.Reminder.FindAsync(id);
            _context.Reminder.Remove(reminder);
            await _context.SaveChangesAsync();
            return Redirect("/Admin");
        }

        public async Task<IActionResult> newTask() {
            return View();

        }

    }
}