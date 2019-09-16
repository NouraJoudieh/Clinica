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

namespace Clinica.Controllers
{
    public class ConsultationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultations
        [Authorize(Roles = "Doctor,Patient,Assistant")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultation
                .Include(c => c.Doctor)
                    .ThenInclude(I => I.ClinicaUser)
                .Include(c => c.Patient)
                    .ThenInclude(u => u.ClinicaUser);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultations/Details/5
        [Authorize(Roles = "Doctor,Patient")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation
                .Include(c => c.Doctor)
                    .ThenInclude(i => i.ClinicaUser)
                .Include(c => c.Patient)
                    .ThenInclude(u => u.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // GET: Consultations/Create
        [Authorize(Roles = "Doctor,Assistant")]
        public IActionResult Create()
        {
            ViewData["Doctors"] = new SelectList(_context.Doctor, "Id", "Id");
            ViewData["Patients"] = new SelectList(_context.Patient, "Id", "Id");
            return View();
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,Title,Type,Date,Symptoms,Diagnosis,Temperature,BloodPressure,Cost,Treatment")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                Consultation con = new Consultation();
                var d = _context.Users.Where(u => u.UserName.Contains(consultation.DoctorId)).FirstOrDefault();
                var p = _context.Users.Where(u => u.UserName.Contains(consultation.PatientId)).FirstOrDefault();
                var doc = await _context.Doctor.FindAsync(d.Id);
                var patient = await _context.Patient.FindAsync(p.Id);
                con.Doctor = doc;
                con.Patient = patient;
                con.Id = consultation.Id;
                con.Title = consultation.Title;
                con.Treatment = consultation.Treatment;
                con.Date = consultation.Date;
                con.Symptoms = consultation.Symptoms;
                con.Type = consultation.Type;
                con.Temperature = consultation.Temperature;
                con.Diagnosis = consultation.Diagnosis;
                con.Cost = consultation.Cost;
                con.BloodPressure = consultation.BloodPressure;

                _context.Add(con);
                await _context.SaveChangesAsync();
                return Redirect("/Reports/Create");
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", consultation.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", consultation.PatientId);
            return View(consultation);
        }

        // GET: Consultations/Edit/5
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation.FindAsync(id);
            if (consultation == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", consultation.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", consultation.PatientId);
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PatientId,DoctorId,Title,Type,Date,Symptoms,Diagnosis,Temperature,BloodPressure,Cost,Treatment,InsuranceConfirmation")] Consultation consultation)
        {
            if (id != consultation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    Consultation con = new Consultation();
                    var d = _context.Users.Where(u => u.UserName.Contains(consultation.DoctorId)).FirstOrDefault();
                    var p = _context.Users.Where(u => u.UserName.Contains(consultation.PatientId)).FirstOrDefault();
                    var doc = await _context.Doctor.FindAsync(d.Id);
                    var patient = await _context.Patient.FindAsync(p.Id);
                    con.Doctor = doc;
                    con.Patient = patient;
                    con.Id = consultation.Id;
                    con.Title = consultation.Title;
                    con.Treatment = consultation.Treatment;
                    con.Date = consultation.Date;
                    con.Symptoms = consultation.Symptoms;
                    con.Type = consultation.Type;
                    con.Temperature = consultation.Temperature;
                    con.Diagnosis = consultation.Diagnosis;
                    con.Cost = consultation.Cost;
                    con.BloodPressure = consultation.BloodPressure;
                    _context.Update(con);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationExists(consultation.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", consultation.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", consultation.PatientId);
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consultation = await _context.Consultation.FindAsync(id);
            _context.Consultation.Remove(consultation);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Doctor"))
            {
                return Redirect("/Doctors/Dashboard");
            }
            else
                return Redirect("/Assistants/Dashboard");
        }

        private bool ConsultationExists(string id)
        {
            return _context.Consultation.Any(e => e.Id == id);
        }
    }
}
