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
    public class SAddressesController : Controller
    {
        private readonly MEventsV2DbContext _context;

        public SAddressesController(MEventsV2DbContext context)
        {
            _context = context;
        }

        // GET: SAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SAddresses.ToListAsync());
        }

        // GET: SAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAddress = await _context.SAddresses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sAddress == null)
            {
                return NotFound();
            }

            return View(sAddress);
        }

        // GET: SAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Postcode,City,State")] SAddress sAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sAddress);
        }

        // GET: SAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAddress = await _context.SAddresses.FindAsync(id);
            if (sAddress == null)
            {
                return NotFound();
            }
            return View(sAddress);
        }

        // POST: SAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Postcode,City,State")] SAddress sAddress)
        {
            if (id != sAddress.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SAddressExists(sAddress.ID))
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
            return View(sAddress);
        }

        // GET: SAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAddress = await _context.SAddresses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sAddress == null)
            {
                return NotFound();
            }

            return View(sAddress);
        }

        // POST: SAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sAddress = await _context.SAddresses.FindAsync(id);
            _context.SAddresses.Remove(sAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SAddressExists(int id)
        {
            return _context.SAddresses.Any(e => e.ID == id);
        }
    }
}
