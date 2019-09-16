
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
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        [Authorize(Roles = "Doctor,Patient,Assistant")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointment
                .Include(a => a.Doctor)
                    .ThenInclude(i=>i.ClinicaUser)
                .Include(a => a.Patient)
                    .ThenInclude(u=>u.ClinicaUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        [Authorize(Roles = "Doctor,Patient,Assistant")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .ThenInclude(i => i.ClinicaUser)
                .Include(a => a.Patient)
                .ThenInclude(u => u.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        [Authorize(Roles = "Doctor,Assistant")]
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,DateTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                Appointment app = new Appointment();
                var d = _context.Users.Where(u => u.UserName.Contains(appointment.DoctorId)).FirstOrDefault();
                var p = _context.Users.Where(u => u.UserName.Contains(appointment.PatientId)).FirstOrDefault();
                var doc = await _context.Doctor.FindAsync(d.Id);
                var patient = await _context.Patient.FindAsync(p.Id);
                app.Doctor = doc;
                app.Patient = patient;
                app.Id = appointment.Id;
                app.DateTime = appointment.DateTime;

                _context.Add(app);
                await _context.SaveChangesAsync();
                if (User.IsInRole("Doctor"))
                {
                    return Redirect("/Doctors/Dashboard");
                }
                else
                    return Redirect("/Assistants/Dashboard");
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PatientId,DoctorId,DateTime")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Appointment app = new Appointment();
                    var d = _context.Users.Where(u => u.UserName.Contains(appointment.DoctorId)).FirstOrDefault();
                    var p = _context.Users.Where(u => u.UserName.Contains(appointment.PatientId)).FirstOrDefault();
                    var doc = await _context.Doctor.FindAsync(d.Id);
                    var patient = await _context.Patient.FindAsync(p.Id);
                    app.Doctor = doc;
                    app.Patient = patient;
                    app.Id = appointment.Id;
                    app.DateTime = appointment.DateTime;
                    _context.Update(app);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5

        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Doctor"))
            {
                return Redirect("/Doctors/Dashboard");
            }
            else
                return Redirect("/Assistants/Dashboard");
        }

        private bool AppointmentExists(string id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
