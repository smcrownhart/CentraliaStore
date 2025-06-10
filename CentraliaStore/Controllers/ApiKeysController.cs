using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentraliaStore.Data;
using CentraliaStore.Models;

namespace CentraliaStore.Controllers
{
    public class ApiKeysController : Controller
    {
        private readonly StoreContext _context;

        public ApiKeysController(StoreContext context)
        {
            _context = context;
        }

        // GET: ApiKeys
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.ApiKeys.Include(a => a.AppUser);
            return View(await storeContext.ToListAsync());
        }

        // GET: ApiKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiKey = await _context.ApiKeys
                .Include(a => a.AppUser)
                .FirstOrDefaultAsync(m => m.ApiKeyId == id);
            if (apiKey == null)
            {
                return NotFound();
            }

            return View(apiKey);
        }

        // GET: ApiKeys/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ApiKeys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApiKeyId,ApiSecret,AppUserId")] ApiKey apiKey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", apiKey.AppUserId);
            return View(apiKey);
        }

        // GET: ApiKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiKey = await _context.ApiKeys.FindAsync(id);
            if (apiKey == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", apiKey.AppUserId);
            return View(apiKey);
        }

        // POST: ApiKeys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApiKeyId,ApiSecret,AppUserId")] ApiKey apiKey)
        {
            if (id != apiKey.ApiKeyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApiKeyExists(apiKey.ApiKeyId))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", apiKey.AppUserId);
            return View(apiKey);
        }

        // GET: ApiKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiKey = await _context.ApiKeys
                .Include(a => a.AppUser)
                .FirstOrDefaultAsync(m => m.ApiKeyId == id);
            if (apiKey == null)
            {
                return NotFound();
            }

            return View(apiKey);
        }

        // POST: ApiKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiKey = await _context.ApiKeys.FindAsync(id);
            if (apiKey != null)
            {
                _context.ApiKeys.Remove(apiKey);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApiKeyExists(int id)
        {
            return _context.ApiKeys.Any(e => e.ApiKeyId == id);
        }
    }
}
