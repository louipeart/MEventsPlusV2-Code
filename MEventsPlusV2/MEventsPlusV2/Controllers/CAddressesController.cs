using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEventsPlusV2.Data;
using MEventsPlusV2.Models;

namespace MEventsPlusV2.Controllers
{
    public class CAddressesController : Controller
    {
        private readonly MEventsV2DbContext _context;

        public CAddressesController(MEventsV2DbContext context)
        {
            _context = context;
        }

        // GET: CAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CAddresses.ToListAsync());
        }

        // GET: CAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAddress = await _context.CAddresses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cAddress == null)
            {
                return NotFound();
            }

            return View(cAddress);
        }

        // GET: CAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Postcode,City,State")] CAddress cAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cAddress);
        }

        // GET: CAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAddress = await _context.CAddresses.FindAsync(id);
            if (cAddress == null)
            {
                return NotFound();
            }
            return View(cAddress);
        }

        // POST: CAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Postcode,City,State")] CAddress cAddress)
        {
            if (id != cAddress.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAddressExists(cAddress.ID))
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
            return View(cAddress);
        }

        // GET: CAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAddress = await _context.CAddresses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cAddress == null)
            {
                return NotFound();
            }

            return View(cAddress);
        }

        // POST: CAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cAddress = await _context.CAddresses.FindAsync(id);
            _context.CAddresses.Remove(cAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CAddressExists(int id)
        {
            return _context.CAddresses.Any(e => e.ID == id);
        }
    }
}
