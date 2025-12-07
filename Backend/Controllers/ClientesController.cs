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
    public class ClientesController : ControllerBase
    {
        private readonly FideliumContext _context;

        public ClientesController(FideliumContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes([FromQuery] string filter = "")
        {
            // El Context ya filtra los activos (Global Query Filter)
            return await _context.Clientes
                .Include(c => c.Usuario)
                .Where(c => c.Usuario != null && (c.Usuario.Nombre.Contains(filter) || c.Usuario.DNI.Contains(filter)))
                .ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (cliente == null) return NotFound();

            return cliente;
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            // Verificación de integridad: ¿El Usuario ya es un cliente?
            if (await _context.Clientes.AnyAsync(c => c.UsuarioID == cliente.UsuarioID))
            {
                return BadRequest("Este usuario ya está registrado como cliente.");
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ID }, cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ID) return BadRequest("El ID no coincide con el registro.");

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Clientes/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            cliente.IsDeleted = true;
            cliente.DeleteDate = DateTime.Now; // Auditoría semántica

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/Clientes/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCliente(int id)
        {
            var cliente = await _context.Clientes
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.ID == id);

            if (cliente == null) return NotFound();

            cliente.IsDeleted = false;
            cliente.DeleteDate = DateTime.MinValue;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Clientes/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesDeleteds()
        {
            return await _context.Clientes
                .IgnoreQueryFilters()
                .Where(c => c.IsDeleted)
                .Include(c => c.Usuario)
                .ToListAsync();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ID == id);
        }
    }
}