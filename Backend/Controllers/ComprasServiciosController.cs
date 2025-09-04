using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

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
                .Include(u => u.Usuario)       //trae el usuario que hizo la venta/servicio
                .Include(c => c.Cliente)      //trae el cliente dentro de la compra
                .ToListAsync();
        }

        // GET: api/ComprasServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraServicio>> GetCompraServicio(int id)
        {
            var compraServicio = await _context.ComprasServicios.FindAsync(id);

            if (compraServicio == null)
            {
                return NotFound();
            }

            return compraServicio;
        }

        // PUT: api/ComprasServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraServicio(int id, CompraServicio compraServicio)
        {
            if (id != compraServicio.ID)
            {
                return BadRequest();
            }

            _context.Entry(compraServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraServicioExists(id))
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

        // POST: api/ComprasServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraServicio>> PostCompraServicio(CompraServicio compraServicio)
        {
            _context.ComprasServicios.Add(compraServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompraServicio", new { id = compraServicio.ID }, compraServicio);
        }

        //// DELETE: api/ComprasServicios/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompraServicio(int id)
        //{
        //    var compraServicio = await _context.ComprasServicios.FindAsync(id);
        //    if (compraServicio == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ComprasServicios.Remove(compraServicio);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraServicios(int id)
        {
            var compraServicios = await _context.ComprasServicios.FindAsync(id);
            if (compraServicios == null)
            {
                return NotFound();
            }
            compraServicios.IsDeleted = true; //esto es un soft delete
            _context.ComprasServicios.Update(compraServicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCompraServicio(int id)
        {
            var compraServicios = await _context.ComprasServicios.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.ID.Equals(id));
            if (compraServicios == null)
            {
                return NotFound();
            }
            compraServicios.IsDeleted = false; //esto es un soft restore
            _context.ComprasServicios.Update(compraServicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Capacitaciones/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<CompraServicio>>> GetCompraServicioDeleteds()
        {

            return await _context.ComprasServicios.IgnoreQueryFilters().Where(cs => cs.IsDeleted).ToListAsync();
        }

        private bool CompraServicioExists(int id)
        {
            return _context.ComprasServicios.Any(e => e.ID == id);
        }
    }
}
