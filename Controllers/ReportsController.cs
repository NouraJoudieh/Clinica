using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Clinica.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminController> _logger;
        private readonly SignInManager<ClinicaUser> _signInManager;

        public ReportsController(ApplicationDbContext context,
            SignInManager<ClinicaUser> signInManager,
        ILogger<AdminController> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _logger = logger;
        }

        // GET: Reports
        [Authorize(Roles = "InsuranceCompany")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reports
                .Include(r => r.Consultation)
                .Include(r => r.InsuranceCompany);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reports/Details/5
        [Authorize(Roles = "InsuranceCompany")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .Include(r => r.Consultation)
                .Include(r => r.InsuranceCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // GET: Reports/Create
        [Authorize(Roles = "Doctor,Assistant")]
        public IActionResult Create()
        {
            ViewData["ConsultationId"] = new SelectList(_context.Consultation, "Id", "Id");
            ViewData["InsuranceCompanyId"] = new SelectList(_context.InsuranceCompany, "Id", "Id");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> Create([Bind("Id,ConsultationId,InsuranceCompanyId,Date")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                var insurance = _context.Users.Where(u => u.UserName.Contains(reports.InsuranceCompanyId)).FirstOrDefault();
                var company = await _context.InsuranceCompany.FindAsync(insurance.Id);
                reports.InsuranceCompany = company;
                _context.Add(reports);
                await _context.SaveChangesAsync();
                if (User.IsInRole("Doctor"))
                {
                    return Redirect("/Doctors/Dashboard");
                }
                else
                    return Redirect("/Assistants/Dashboard");
            }
            ViewData["ConsultationId"] = new SelectList(_context.Consultation, "Id", "Id", reports.ConsultationId);
            ViewData["InsuranceCompanies"] = new SelectList(_context.InsuranceCompany, "Id", "Id", reports.InsuranceCompanyId);
            return View(reports);
        }

        // GET: Reports/Edit/5
        [Authorize(Roles = "InsuranceCompany")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            ViewData["ConsultationId"] = new SelectList(_context.Consultation, "Id", "Id", reports.ConsultationId);
            ViewData["InsuranceCompanyId"] = new SelectList(_context.InsuranceCompany, "Id", "Id", reports.InsuranceCompanyId);
            return View(reports);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "InsuranceCompany")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ConsultationId,InsuranceCompanyId,Date")] Reports reports)
        {
            if (id != reports.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsExists(reports.Id))
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
                else if (User.IsInRole("Assistant"))
                    return Redirect("/Assistants/Dashboard");
                return Redirect("/InsuranceCompanies/Dashboard");
            }
            ViewData["ConsultationId"] = new SelectList(_context.Consultation, "Id", "Id", reports.ConsultationId);
            ViewData["InsuranceCompanyId"] = new SelectList(_context.InsuranceCompany, "Id", "Id", reports.InsuranceCompanyId);
            return View(reports);
        }

        // GET: Reports/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .Include(r => r.Consultation)
                .Include(r => r.InsuranceCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reports = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(reports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsExists(string id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }
    }
}
