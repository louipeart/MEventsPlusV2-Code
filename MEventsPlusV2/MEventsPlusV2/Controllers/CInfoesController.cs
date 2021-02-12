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
    public class CInfoesController : Controller
    {
        private readonly MEventsV2DbContext _context;

        public CInfoesController(MEventsV2DbContext context)
        {
            _context = context;
        }

        // GET: CInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CInfos.ToListAsync());
        }

        // GET: CInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cInfo = await _context.CInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cInfo == null)
            {
                return NotFound();
            }

            return View(cInfo);
        }

        // GET: CInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FName,LName,Dateofbirth,Telno,Email")] CInfo cInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cInfo);
        }

        // GET: CInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cInfo = await _context.CInfos.FindAsync(id);
            if (cInfo == null)
            {
                return NotFound();
            }
            return View(cInfo);
        }

        // POST: CInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FName,LName,Dateofbirth,Telno,Email")] CInfo cInfo)
        {
            if (id != cInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CInfoExists(cInfo.ID))
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
            return View(cInfo);
        }

        // GET: CInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cInfo = await _context.CInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cInfo == null)
            {
                return NotFound();
            }

            return View(cInfo);
        }

        // POST: CInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cInfo = await _context.CInfos.FindAsync(id);
            _context.CInfos.Remove(cInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CInfoExists(int id)
        {
            return _context.CInfos.Any(e => e.ID == id);
        }
    }
}
