using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetalleInscripcionesController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiDetalleInscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetalleInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleInscripcion>>> Getdetallesinscripciones()
        {
            return await _context.detallesinscripciones.ToListAsync();
        }

        // GET: api/ApiDetalleInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleInscripcion>> GetDetalleInscripcion(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);

            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return detalleInscripcion;
        }

        // PUT: api/ApiDetalleInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleInscripcion(int id, DetalleInscripcion detalleInscripcion)
        {
            if (id != detalleInscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleInscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleInscripcionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiDetalleInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleInscripcion>> PostDetalleInscripcion(DetalleInscripcion detalleInscripcion)
        {
            _context.detallesinscripciones.Add(detalleInscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleInscripcion", new { id = detalleInscripcion.Id }, detalleInscripcion);
        }

        // DELETE: api/ApiDetalleInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleInscripcion(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            _context.detallesinscripciones.Remove(detalleInscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleInscripcionExists(int id)
        {
            return _context.detallesinscripciones.Any(e => e.Id == id);
        }
    }
}
