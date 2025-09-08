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
            return await _context.Notificaciones
                .Include(n => n.CompraServicio)       // Trae la compra/servicio
                .ThenInclude(c => c.Cliente)      // Trae el cliente dentro de la compra
                .Include(u => u.Empleado) // Trae el usuario que hizo la venta/servicio
                .ToListAsync();
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacion>> GetNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);

            if (notificacion == null)
            {
                return NotFound();
            }

            return notificacion;
        }

        // PUT: api/Notificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacion(int id, Notificacion notificacion)
        {
            if (id != notificacion.ID)
            {
                return BadRequest();
            }

            _context.Entry(notificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionExists(id))
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

        // POST: api/Notificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notificacion>> PostNotificacion(Notificacion notificacion)
        {
            // Antes de agregar la notificación
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.UsuarioID == notificacion.ClienteID && !c.IsDeleted);
            
            if (!clienteExiste)
            {
                return BadRequest("El Cliente no existe.");
            }

            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacion", new { id = notificacion.ID }, notificacion);
        }

        //// DELETE: api/Notificaciones/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteNotificacion(int id)
        //{
        //    var notificacion = await _context.Notificaciones.FindAsync(id);
        //    if (notificacion == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Notificaciones.Remove(notificacion);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }
            notificacion.IsDeleted = true; //esto es un soft delete
            _context.Notificaciones.Update(notificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.ID.Equals(id));
            if (notificacion == null)
            {
                return NotFound();
            }
            notificacion.IsDeleted = false; //esto es un soft restore
            _context.Notificaciones.Update(notificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Capacitaciones/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Notificacion>>> GetNotificacionesDeleteds()
        {

            return await _context.Notificaciones.IgnoreQueryFilters().Where(n => n.IsDeleted)
                .Include(n => n.CompraServicio)       // Trae la compra/servicio
                .ThenInclude(c => c.Cliente)      // Trae el cliente dentro de la compra
                .Include(u => u.Empleado) // Trae el usuario que hizo la venta/servicio
                .ToListAsync();
        }


        private bool NotificacionExists(int id)
        {
            return _context.Notificaciones.Any(e => e.ID == id);
        }
    }
}
