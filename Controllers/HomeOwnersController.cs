using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeOwnersApp.Data;
using HomeOwnersApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeOwnersApp.Controllers
{
    [Authorize]
    public class HomeOwnersController : Controller
    {
        private readonly AppDataContext _context;

        public HomeOwnersController(AppDataContext context)
        {
            _context = context;
        }

        // GET: HomeOwners
        public async Task<IActionResult> Index()
        {
              return _context.HomeOwners != null ? 
                          View(await _context.HomeOwners.ToListAsync()) :
                          Problem("Entity set 'AppDataContext.HomeOwners'  is null.");
        }

        // GET: HomeOwners/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.HomeOwners == null)
            {
                return NotFound();
            }

            var homeOwners = await _context.HomeOwners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeOwners == null)
            {
                return NotFound();
            }

            return View(homeOwners);
        }

        // GET: HomeOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeOwners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,Age,Site")] HomeOwners homeOwners)
        {
            if (ModelState.IsValid)
            {
                homeOwners.Id = Guid.NewGuid();
                _context.Add(homeOwners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeOwners);
        }

        // GET: HomeOwners/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.HomeOwners == null)
            {
                return NotFound();
            }

            var homeOwners = await _context.HomeOwners.FindAsync(id);
            if (homeOwners == null)
            {
                return NotFound();
            }
            return View(homeOwners);
        }

        // POST: HomeOwners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,PhoneNumber,Age,Site")] HomeOwners homeOwners)
        {
            if (id != homeOwners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeOwners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeOwnersExists(homeOwners.Id))
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
            return View(homeOwners);
        }

        // GET: HomeOwners/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.HomeOwners == null)
            {
                return NotFound();
            }

            var homeOwners = await _context.HomeOwners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeOwners == null)
            {
                return NotFound();
            }

            return View(homeOwners);
        }

        // POST: HomeOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.HomeOwners == null)
            {
                return Problem("Entity set 'AppDataContext.HomeOwners'  is null.");
            }
            var homeOwners = await _context.HomeOwners.FindAsync(id);
            if (homeOwners != null)
            {
                _context.HomeOwners.Remove(homeOwners);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeOwnersExists(Guid id)
        {
          return (_context.HomeOwners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
