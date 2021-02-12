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
    public class SInfoesController : Controller
    {
        private readonly MEventsV2DbContext _context;

        public SInfoesController(MEventsV2DbContext context)
        {
            _context = context;
        }

        // GET: SInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SInfos.ToListAsync());
        }

        // GET: SInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sInfo = await _context.SInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sInfo == null)
            {
                return NotFound();
            }

            return View(sInfo);
        }

        // GET: SInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FName,LName,Email,Telno,Jobrole")] SInfo sInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sInfo);
        }

        // GET: SInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sInfo = await _context.SInfos.FindAsync(id);
            if (sInfo == null)
            {
                return NotFound();
            }
            return View(sInfo);
        }

        // POST: SInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FName,LName,Email,Telno,Jobrole")] SInfo sInfo)
        {
            if (id != sInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SInfoExists(sInfo.ID))
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
            return View(sInfo);
        }

        // GET: SInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sInfo = await _context.SInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sInfo == null)
            {
                return NotFound();
            }

            return View(sInfo);
        }

        // POST: SInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sInfo = await _context.SInfos.FindAsync(id);
            _context.SInfos.Remove(sInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SInfoExists(int id)
        {
            return _context.SInfos.Any(e => e.ID == id);
        }
    }
}
