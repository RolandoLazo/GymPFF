using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymPFF.Models;

namespace GymPFF.Controllers
{
    public class ClaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clase
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clases.Include(c => c.Actividad).Include(c => c.Cliente).Include(c => c.Empleado).Include(c => c.Sala);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .Include(c => c.Actividad)
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Sala)
                .FirstOrDefaultAsync(m => m.ClaseId == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clase/Create
        public IActionResult Create()
        {
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "ActividadId", "ActividadId");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId");
            ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "SalaId");
            return View();
        }

        // POST: Clase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaseId,DiaEstablecido,HInicio,SalaId,ActividadId,EmpleadoId,ClienteId")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "ActividadId", "ActividadId", clase.ActividadId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", clase.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", clase.EmpleadoId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "SalaId", clase.SalaId);
            return View(clase);
        }

        // GET: Clase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "ActividadId", "ActividadId", clase.ActividadId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", clase.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", clase.EmpleadoId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "SalaId", clase.SalaId);
            return View(clase);
        }

        // POST: Clase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaseId,DiaEstablecido,HInicio,SalaId,ActividadId,EmpleadoId,ClienteId")] Clase clase)
        {
            if (id != clase.ClaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseExists(clase.ClaseId))
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
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "ActividadId", "ActividadId", clase.ActividadId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", clase.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", clase.EmpleadoId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "SalaId", clase.SalaId);
            return View(clase);
        }

        // GET: Clase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .Include(c => c.Actividad)
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Sala)
                .FirstOrDefaultAsync(m => m.ClaseId == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // POST: Clase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.ClaseId == id);
        }
    }
}
