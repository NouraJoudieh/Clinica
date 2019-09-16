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
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ClinicaUser> _signInManager;

        public MessagesController(ApplicationDbContext context, SignInManager<ClinicaUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: Messages
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Messages.Include(m => m.ClinicaUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Messages/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .Include(m => m.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // GET: Messages/Create
        [Authorize(Roles = "Doctor")]
        public IActionResult Create()
        {
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Create([Bind("Id,Subject,Body")] Messages messages)
        {
            messages.Date = DateTime.Now;
            var currentUser = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            messages.Email = currentUser.Email;
            if (ModelState.IsValid)
            {
                _context.Add(messages);
                await _context.SaveChangesAsync();
                return Redirect("/Doctors/Dashboard");
            }
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", messages.ClinicaUserId);
            return View(messages);
        }

        // GET: Messages/Edit/5
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", messages.ClinicaUserId);
            return View(messages);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ClinicaUserId,Subject,Body,Email,Date")] Messages messages)
        {
            if (id != messages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessagesExists(messages.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Doctors/Dashboard");
            }
            ViewData["ClinicaUserId"] = new SelectList(_context.Set<ClinicaUser>(), "Id", "Id", messages.ClinicaUserId);
            return View(messages);
        }

        // GET: Messages/Delete/5
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .Include(m => m.ClinicaUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var messages = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(messages);
            await _context.SaveChangesAsync();
            return Redirect("/Doctors/Dashboard");
        }

        private bool MessagesExists(string id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
