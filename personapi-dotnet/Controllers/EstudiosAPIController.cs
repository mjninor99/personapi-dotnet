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
    [Route("EstudiosAPI/[controller]")]
    public class EstudiosAPIController : Controller
    {
        private readonly PersonaDbContext _context;

        public EstudiosAPIController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: Estudios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var personaDbContext = _context.Estudios.Include(e => e.CcPerNavigation).Include(e => e.IdProfNavigation);
            return View(await personaDbContext.ToListAsync());
        }

        // GET: Estudios/Details/5/5
        [HttpGet("Details/{idProf}/{ccPer}")]
        public async Task<IActionResult> Details(int? idProf, int? ccPer)
        {
            if (idProf == null || ccPer == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == idProf && m.CcPer == ccPer);

            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudios/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc");
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id");
            return View();
        }

        // POST: Estudios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudios/Edit/5
        [HttpGet("Edit/{idProf}/{ccPer}")]
        public async Task<IActionResult> Edit(int? idProf, int? ccPer)
        {
            if (idProf == null || ccPer == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int IdProf, int CcPer, [Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (IdProf != estudio.IdProf || CcPer != estudio.CcPer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudioExists(estudio.IdProf, estudio.CcPer))
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
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudios/Delete/5
        [HttpGet("Delete/{idProf}/{ccPer}")]
        public async Task<IActionResult> Delete(int? idProf, int? ccPer)
        {
            if (idProf == null || ccPer == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == idProf && m.CcPer == ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: Estudios/Delete/5
        [HttpDelete("Delete/{idProf}/{ccPer}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idProf, int ccPer)
        {
            if (_context.Estudios == null)
            {
                return Problem("Entity set 'PersonaDbContext.Estudios'  is null.");
            }
            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudioExists(int idProf, int ccPer)
        {
            return (_context.Estudios?.Any(e => e.IdProf == idProf && e.CcPer == ccPer)).GetValueOrDefault();
        }

    }
}
