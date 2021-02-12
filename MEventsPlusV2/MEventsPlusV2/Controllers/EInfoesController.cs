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
    public class EInfoesController : Controller
    {
        private readonly MEventsV2DbContext _context;

        public EInfoesController(MEventsV2DbContext context)
        {
            _context = context;
        }

        // GET: EInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EInfos.ToListAsync());
        }

        // GET: EInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eInfo = await _context.EInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eInfo == null)
            {
                return NotFound();
            }

            return View(eInfo);
        }

        // GET: EInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Mname,Price,Date,Time,Availability")] EInfo eInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eInfo);
        }

        // GET: EInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eInfo = await _context.EInfos.FindAsync(id);
            if (eInfo == null)
            {
                return NotFound();
            }
            return View(eInfo);
        }

        // POST: EInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Mname,Price,Date,Time,Availability")] EInfo eInfo)
        {
            if (id != eInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EInfoExists(eInfo.ID))
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
            return View(eInfo);
        }

        // GET: EInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eInfo = await _context.EInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eInfo == null)
            {
                return NotFound();
            }

            return View(eInfo);
        }

        // POST: EInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eInfo = await _context.EInfos.FindAsync(id);
            _context.EInfos.Remove(eInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EInfoExists(int id)
        {
            return _context.EInfos.Any(e => e.ID == id);
        }
    }
}
