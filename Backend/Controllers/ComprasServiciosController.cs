using Backend.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using Service.Models.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasServiciosController : ControllerBase
    {
        private readonly FideliumContext _context;

        public ComprasServiciosController(FideliumContext context)
        {
            _context = context;
        }

        // GET: api/ComprasServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraServicio>>> GetComprasServicios()
        {
            return await _context.ComprasServicios
                .Include(cs => cs.Cliente)
                    .ThenInclude(c => c.Usuario) // Nombre y DNI del Cliente
                .Include(cs => cs.Empleado)     // Nombre y DNI del Empleado
                .ToListAsync();
        }

        // GET: api/ComprasServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraServicio>> GetCompraServicio(int id)
        {
            var compraServicio = await _context.ComprasServicios
                .Include(cs => cs.Cliente)
                    .ThenInclude(c => c.Usuario)
                .Include(cs => cs.Empleado)
                .FirstOrDefaultAsync(cs => cs.ID == id);

            if (compraServicio == null) return NotFound();

            return compraServicio;
        }

        // POST: api/ComprasServicios
        [HttpPost]
        public async Task<ActionResult<CompraServicio>> PostCompraServicio(CompraServicio compraServicio)
        {
            // El modelo ya trae la lógica de FechaRecordatorio calculada
            _context.ComprasServicios.Add(compraServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompraServicio", new { id = compraServicio.ID }, compraServicio);
        }

        // PUT: api/ComprasServicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraServicio(int id, CompraServicio compraServicio)
        {
            if (id != compraServicio.ID) return BadRequest();

            _context.Entry(compraServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraServicioExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/ComprasServicios/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraServicio(int id)
        {
            var compra = await _context.ComprasServicios.FindAsync(id);
            if (compra == null) return NotFound();

            compra.IsDeleted = true;
            _context.ComprasServicios.Update(compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/ComprasServicios/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCompraServicio(int id)
        {
            var compra = await _context.ComprasServicios.IgnoreQueryFilters()
                .FirstOrDefaultAsync(cs => cs.ID == id);

            if (compra == null) return NotFound();

            compra.IsDeleted = false;
            _context.ComprasServicios.Update(compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/ComprasServicios/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<CompraServicio>>> GetCompraServicioDeleteds()
        {
            return await _context.ComprasServicios.IgnoreQueryFilters()
                .Where(cs => cs.IsDeleted)
                .Include(cs => cs.Cliente)
                    .ThenInclude(c => c.Usuario)
                .Include(cs => cs.Empleado)
                .ToListAsync();
        }

        private bool CompraServicioExists(int id)
        {
            return _context.ComprasServicios.Any(e => e.ID == id);
        }
    }
}