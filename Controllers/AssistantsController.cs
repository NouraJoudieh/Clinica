
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
    
    public class AssistantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssistantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assistants
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assistant.Include(a => a.ClinicaUser).Include(a => a.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Assistant")]
        public async Task<IActionResult> Dashboard()
        {
            Users user = new Users();
            return View(user);
        }
        // GET: Assistants/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistant
                .Include(a => a.ClinicaUser)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assistant == null)
            {
                return NotFound();
            }

            return View(assistant);
        }

        // GET: Assistants/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id");
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id");
            return View();
        }

        // POST: Assistants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,Gender")] Assistant assistant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assistant);
                await _context.SaveChangesAsync();
                return Redirect("/Admin");
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", assistant.Id);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", assistant.DoctorId);
            return View(assistant);
        }

        // GET: Assistants/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistant.FindAsync(id);
            if (assistant == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", assistant.Id);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", assistant.DoctorId);
            return View(assistant);
        }

        // POST: Assistants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DoctorId,Gender")] Assistant assistant)
        {
            if (id != assistant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistantExists(assistant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin");
            }
            ViewData["Id"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", assistant.Id);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", assistant.DoctorId);
            return View(assistant);
        }

        // GET: Assistants/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.Assistant
                .Include(a => a.ClinicaUser)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assistant == null)
            {
                return NotFound();
            }

            return View(assistant);
        }

        // POST: Assistants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var assistant = await _context.Assistant.FindAsync(id);
            _context.Assistant.Remove(assistant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistantExists(string id)
        {
            return _context.Assistant.Any(e => e.Id == id);
        }
    }
}
