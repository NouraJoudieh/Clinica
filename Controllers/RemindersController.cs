
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
    [Authorize(Roles = "Admin")]
    public class RemindersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RemindersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reminders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reminder.Include(r => r.ClinicaUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reminders/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: Reminders/Create
        public IActionResult Create()
        {
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id");
            return View();
        }

        // POST: Reminders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClinicaUserId,DateTime,Content,Priority,Title")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reminder);
                await _context.SaveChangesAsync();
                return Redirect("/Admin");
            }
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", reminder.ClinicaUserId);
            return View(reminder);
        }

        // GET: Reminders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", reminder.ClinicaUserId);
            return View(reminder);
        }

        // POST: Reminders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ClinicaUserId,DateTime,Content,Priority,Title")] Reminder reminder)
        {
            if (id != reminder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reminder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReminderExists(reminder.Id))
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
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", reminder.ClinicaUserId);
            return View(reminder);
        }

        // GET: Reminders/Delete/5
        public async Task<IActionResult> Delete(string id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reminder = await _context.Reminder.FindAsync(id);
            _context.Reminder.Remove(reminder);
            await _context.SaveChangesAsync();
            return Redirect("/Admin");
        }

        private bool ReminderExists(string id)
        {
            return _context.Reminder.Any(e => e.Id == id);
        }
    }
}
