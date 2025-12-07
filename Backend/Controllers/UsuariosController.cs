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
    public class UsuariosController : ControllerBase
    {
        private readonly FideliumContext _context;

        public UsuariosController(FideliumContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            // El filtro HasQueryFilter en el Context ya se encarga de excluir los IsDeleted
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) return NotFound();

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.ID }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.ID) return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Usuarios/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            // Seteamos la fecha de eliminación para auditoría si lo deseas
            usuario.IsDeleted = true;
            usuario.DeleteDate = DateTime.Now;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Usuarios/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreUsuario(int id)
        {
            // Usamos .ID == id en lugar de .Equals por semántica de tipos numéricos
            var usuario = await _context.Usuarios.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.ID == id);

            if (usuario == null) return NotFound();

            usuario.IsDeleted = false;
            usuario.DeleteDate = DateTime.MinValue; // Reseteamos la fecha

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Usuarios/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuariosDeleteds()
        {
            // Cambiado el nombre del método a GetUsuariosDeleteds para ser coherente
            return await _context.Usuarios.IgnoreQueryFilters()
                .Where(u => u.IsDeleted)
                .ToListAsync();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.ID == id);
        }
    }
}