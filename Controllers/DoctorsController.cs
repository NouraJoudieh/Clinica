using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Clinica.Controllers
{
  
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doctors
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctor.Include(d => d.ClinicaUser);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Dashboard() {
            Users user=new Users();
            return View(user);
        }

        [Authorize(Roles = "Admin,Patient")]
        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Gender,Speciality,AvailableFrom,AvailableTo,Address,About")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", doctor.Id);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", doctor.Id);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Gender,Speciality,AvailableFrom,AvailableTo,Address,About")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", doctor.Id);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(string id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }

        public IActionResult ViewPatients() {
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Clinica.Models.Patient> patient = new List<Clinica.Models.Patient>();
            var app = _context.Appointment.Include(a => a.Patient).ThenInclude(p => p.ClinicaUser).Where(a => a.DoctorId.Contains(id)).ToList();
            foreach (var item in app) {
                patient.Add(item.Patient);
            }
            return View(patient);

        }
    }
}
