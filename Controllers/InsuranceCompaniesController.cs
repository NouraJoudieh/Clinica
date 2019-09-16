using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Controllers
{
    
    public class InsuranceCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ClinicaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<InsuranceCompaniesController> _logger;


        public InsuranceCompaniesController(ApplicationDbContext context, 
            ILogger<InsuranceCompaniesController> logger, 
            UserManager<ClinicaUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: InsuranceCompanies
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InsuranceCompany.Include(i => i.ClinicaUser);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "InsuranceCompany")]
        public IActionResult Dashboard()
        {
            return Redirect("/InsuranceCompanies/ViewReports");
        }

        // GET: InsuranceCompanies/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: InsuranceCompanies/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id");
            return View();
        }

        // POST: InsuranceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Address,Fax")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceCompany);
                await _roleManager.CreateAsync(new IdentityRole("InsuranceCompany"));
                //await _userManager.AddToRoleAsync(insuranceCompany, "InsuranceCompany");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", insuranceCompany.Id);
            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompany.FindAsync(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", insuranceCompany.Id);
            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("InsuranceConfirmation")] Consultation consultation)
        {
            if (id != consultation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Consultation.Any(e => e.Id == id))
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
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", consultation.Id);
            return View(consultation);
        }

        // GET: InsuranceCompanies/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompany
                .Include(i => i.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var insuranceCompany = await _context.InsuranceCompany.FindAsync(id);
            _context.InsuranceCompany.Remove(insuranceCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
        [Authorize(Roles = "InsuranceCompany")]
        public async Task<IActionResult> ViewReports() {
           
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _context.Reports
                        .Include(a => a.InsuranceCompany)
                            .ThenInclude(i => i.ClinicaUser)
                        .Include(a => a.Consultation)
                        .Where(r => r.InsuranceCompanyId
                        .Contains(id.ToString()));
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
