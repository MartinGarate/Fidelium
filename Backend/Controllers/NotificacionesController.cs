using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly FideliumContext _context;

        public NotificacionesController(FideliumContext context)
        {
            _context = context;
        }

        // GET: api/Notificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacion>>> GetNotificaciones()
        {
            // Semánticamente, traemos la compra y, desde ella, al cliente y empleado vinculados.
            return await _context.Notificaciones
                .Include(n => n.CompraServicio)
                    .ThenInclude(cs => cs.Cliente)
                        .ThenInclude(c => c.Usuario) // Nombre/DNI del cliente
                .Include(n => n.CompraServicio)
                    .ThenInclude(cs => cs.Empleado) // Nombre/DNI del empleado
                .ToListAsync();
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacion>> GetNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones
                .Include(n => n.CompraServicio)
                .FirstOrDefaultAsync(n => n.ID == id);

            if (notificacion == null) return NotFound();

            return notificacion;
        }

        // POST: api/Notificaciones
        [HttpPost]
        public async Task<ActionResult<Notificacion>> PostNotificacion(Notificacion notificacion)
        {
            // Validación de integridad: ¿Existe la compra a la que queremos notificar?
            var compraExiste = await _context.ComprasServicios.AnyAsync(cs => cs.ID == notificacion.CompraServicioID);

            if (!compraExiste)
            {
                return BadRequest("No se puede generar una notificación para una compra inexistente.");
            }

            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacion", new { id = notificacion.ID }, notificacion);
        }

        // PUT: api/Notificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacion(int id, Notificacion notificacion)
        {
            if (id != notificacion.ID) return BadRequest();

            _context.Entry(notificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Notificaciones/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null) return NotFound();

            notificacion.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Notificaciones/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones.IgnoreQueryFilters()
                .FirstOrDefaultAsync(n => n.ID == id);

            if (notificacion == null) return NotFound();

            notificacion.IsDeleted = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Notificaciones/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Notificacion>>> GetNotificacionesDeleteds()
        {
            return await _context.Notificaciones.IgnoreQueryFilters()
                .Where(n => n.IsDeleted)
                .Include(n => n.CompraServicio)
                    .ThenInclude(cs => cs.Cliente)
                .ToListAsync();
        }

        private bool NotificacionExists(int id)
        {
            return _context.Notificaciones.Any(e => e.ID == id);
        }
    }
}