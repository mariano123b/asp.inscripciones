using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    public class inscripcionesController : Controller
    {
        private readonly InscripcionesContext _context;

        public inscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: inscripciones
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.Inscripciones.Include(i => i.alumnos).Include(i => i.carrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: inscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones
                .Include(i => i.alumnos)
                .Include(i => i.carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            return View(inscripciones);
        }

        // GET: inscripciones/Create
        public IActionResult Create()
        {
            ViewData["Alumnos"] = new SelectList(_context.alumnos, "Id", "ApellidoNombre");
            ViewData["Carrera"] = new SelectList(_context.carreras, "Id", "Nombre");
            return View();
        }

        // POST: inscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fecha,alumnosid,carreraid")] inscripciones inscripciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alumnosid"] = new SelectList(_context.alumnos, "Id", "ApellidoNombre", inscripciones.alumnosid);
            ViewData["carreraid"] = new SelectList(_context.carreras, "Id", "Nombre", inscripciones.carreraid);
            return View(inscripciones);
        }

        // GET: inscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones == null)
            {
                return NotFound();
            }
            ViewData["alumnosid"] = new SelectList(_context.alumnos, "Id", "ApellidoNombre", inscripciones.alumnosid);
            ViewData["carreraid"] = new SelectList(_context.carreras, "Id", "Nombre", inscripciones.carreraid);
            return View(inscripciones);
        }

        // POST: inscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fecha,alumnosid,carreraid")] inscripciones inscripciones)
        {
            if (id != inscripciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inscripcionesExists(inscripciones.Id))
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
            ViewData["alumnosid"] = new SelectList(_context.alumnos, "Id", "ApellidoNombre", inscripciones.alumnosid);
            ViewData["carreraid"] = new SelectList(_context.carreras, "Id", "Nombre", inscripciones.carreraid);
            return View(inscripciones);
        }

        // GET: inscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones
                .Include(i => i.alumnos)
                .Include(i => i.carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            return View(inscripciones);
        }

        // POST: inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones != null)
            {
                _context.Inscripciones.Remove(inscripciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool inscripcionesExists(int id)
        {
            return _context.Inscripciones.Any(e => e.Id == id);
        }
    }
}
