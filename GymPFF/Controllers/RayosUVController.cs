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
    public class RayosUVController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RayosUVController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RayosUV
        public async Task<IActionResult> Index()
        {
            return View(await _context.RayosUV.ToListAsync());
        }

        // GET: RayosUV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rayosUV = await _context.RayosUV
                .FirstOrDefaultAsync(m => m.RayosUVId == id);
            if (rayosUV == null)
            {
                return NotFound();
            }

            return View(rayosUV);
        }

        // GET: RayosUV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RayosUV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RayosUVId,NumCuarto,HoraUso")] RayosUV rayosUV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rayosUV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rayosUV);
        }

        // GET: RayosUV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rayosUV = await _context.RayosUV.FindAsync(id);
            if (rayosUV == null)
            {
                return NotFound();
            }
            return View(rayosUV);
        }

        // POST: RayosUV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RayosUVId,NumCuarto,HoraUso")] RayosUV rayosUV)
        {
            if (id != rayosUV.RayosUVId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rayosUV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RayosUVExists(rayosUV.RayosUVId))
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
            return View(rayosUV);
        }

        // GET: RayosUV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rayosUV = await _context.RayosUV
                .FirstOrDefaultAsync(m => m.RayosUVId == id);
            if (rayosUV == null)
            {
                return NotFound();
            }

            return View(rayosUV);
        }

        // POST: RayosUV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rayosUV = await _context.RayosUV.FindAsync(id);
            _context.RayosUV.Remove(rayosUV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RayosUVExists(int id)
        {
            return _context.RayosUV.Any(e => e.RayosUVId == id);
        }
    }
}
