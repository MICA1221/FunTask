using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunTask.Datos;
using FunTask.Models;

namespace FunTask.Controllers
{
    public class HijosController : Controller
    {
        private readonly FunTaskerContext _context;

        public HijosController(FunTaskerContext context)
        {
            _context = context;
        }

        // GET: Hijos
        public async Task<IActionResult> Index()
        {
            var funTaskerContext = _context.Hijos.Include(h => h.Usuario);
            return View(await funTaskerContext.ToListAsync());
        }

        // GET: Hijos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hijos == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos
                .Include(h => h.Usuario)
                .FirstOrDefaultAsync(m => m.HijoId == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // GET: Hijos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreUsuario");
            return View();
        }

        // POST: Hijos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HijoId,UsuarioId,ImagenPerfil")] Hijo hijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreUsuario", hijo.UsuarioId);
            return View(hijo);
        }

        // GET: Hijos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hijos == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos.FindAsync(id);
            if (hijo == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreUsuario", hijo.UsuarioId);
            return View(hijo);
        }

        // POST: Hijos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HijoId,UsuarioId,ImagenPerfil")] Hijo hijo)
        {
            if (id != hijo.HijoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HijoExists(hijo.HijoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreUsuario", hijo.UsuarioId);
            return View(hijo);
        }

        // GET: Hijos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hijos == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos
                .Include(h => h.Usuario)
                .FirstOrDefaultAsync(m => m.HijoId == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // POST: Hijos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hijos == null)
            {
                return Problem("Entity set 'FunTaskerContext.Hijos'  is null.");
            }
            var hijo = await _context.Hijos.FindAsync(id);
            if (hijo != null)
            {
                _context.Hijos.Remove(hijo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HijoExists(int id)
        {
          return (_context.Hijos?.Any(e => e.HijoId == id)).GetValueOrDefault();
        }
    }
}
