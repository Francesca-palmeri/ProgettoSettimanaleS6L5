using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanaleS6L5.Models;
using ProgettoSettimanaleS6L5.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoSettimanaleS6L5.Controllers
{
    
    public class CamereController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CamereController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Camere
        public async Task<IActionResult> Index()
        {
            var camere = await _context.Camere.ToListAsync();
            return View(camere);
        }

        [Authorize(Roles = "Admin")]
        // GET: Camere/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Camere/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Camera camera)
        {
            if (ModelState.IsValid)
            {
                _context.Camere.Add(camera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Camere");

        }

        [Authorize(Roles = "Admin")]
        // GET: Camere/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var camera = await _context.Camere.FindAsync(id);
            if (camera == null) return NotFound();

            return View(camera);
        }
        [Authorize(Roles = "Admin")]
        // POST: Camere/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Camera camera)
        {
            if (id != camera.CameraId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Camere.Update(camera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraExists(camera.CameraId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(camera);
        }

        [Authorize(Roles = "Admin")]
        // GET: Camere/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var camera = await _context.Camere
                .FirstOrDefaultAsync(m => m.CameraId == id);
            if (camera == null) return NotFound();

            return View(camera);
        }
        [Authorize(Roles = "Admin")]
        // POST: Camere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camera = await _context.Camere.FindAsync(id);
            if (camera != null)
            {
                _context.Camere.Remove(camera);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CameraExists(int id)
        {
            return _context.Camere.Any(e => e.CameraId == id);
        }
    }
}