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
    public class EAddressesController : Controller
    {
        private readonly MEventsV2DbContext _context;

        public EAddressesController(MEventsV2DbContext context)
        {
            _context = context;
        }

        // GET: EAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.EAddresses.ToListAsync());
        }

        // GET: EAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eAddress = await _context.EAddresses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eAddress == null)
            {
                return NotFound();
            }

            return View(eAddress);
        }

        // GET: EAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Postcode,City,State")] EAddress eAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eAddress);
        }

        // GET: EAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eAddress = await _context.EAddresses.FindAsync(id);
            if (eAddress == null)
            {
                return NotFound();
            }
            return View(eAddress);
        }

        // POST: EAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Postcode,City,State")] EAddress eAddress)
        {
            if (id != eAddress.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EAddressExists(eAddress.ID))
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
            return View(eAddress);
        }

        // GET: EAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eAddress = await _context.EAddresses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eAddress == null)
            {
                return NotFound();
            }

            return View(eAddress);
        }

        // POST: EAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eAddress = await _context.EAddresses.FindAsync(id);
            _context.EAddresses.Remove(eAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EAddressExists(int id)
        {
            return _context.EAddresses.Any(e => e.ID == id);
        }
    }
}
