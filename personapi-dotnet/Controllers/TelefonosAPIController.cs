using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("TelefonosAPI/[controller]")]
    public class TelefonosAPIController : Controller
    {
        private readonly PersonaDbContext _context;

        public TelefonosAPIController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: Telefonos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var personaDbContext = _context.Telefonos.Include(t => t.DuenioNavigation);
            return View(await personaDbContext.ToListAsync());
        }

        // GET: Telefonos/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Telefonos == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .FirstOrDefaultAsync(m => m.Num == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefonos/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["Duenio"] = new SelectList(_context.Personas, "Cc", "Cc");
            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Duenio"] = new SelectList(_context.Personas, "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Telefonos == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["Duenio"] = new SelectList(_context.Personas, "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (id != telefono.Num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.Num))
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
            ViewData["Duenio"] = new SelectList(_context.Personas, "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Telefonos == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .FirstOrDefaultAsync(m => m.Num == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpDelete("Edit/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Telefonos == null)
            {
                return Problem("Entity set 'PersonaDbContext.Telefonos'  is null.");
            }
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(string id)
        {
          return (_context.Telefonos?.Any(e => e.Num == id)).GetValueOrDefault();
        }
    }
}
