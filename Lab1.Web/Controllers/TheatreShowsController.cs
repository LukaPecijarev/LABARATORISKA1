﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1.Web.Data;
using Lab1.Web.Models;

namespace Lab1.Web.Controllers
{
    public class TheatreShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheatreShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheatreShows
        public async Task<IActionResult> Index()
        {
              return _context.theatreShows != null ? 
                          View(await _context.theatreShows.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.theatreShows'  is null.");
        }

        // GET: TheatreShows/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.theatreShows == null)
            {
                return NotFound();
            }

            var theatreShow = await _context.theatreShows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatreShow == null)
            {
                return NotFound();
            }

            return View(theatreShow);
        }

        // GET: TheatreShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Place,ShowDate,ImageURL")] TheatreShow theatreShow)
        {
            if (ModelState.IsValid)
            {
                theatreShow.Id = Guid.NewGuid();
                _context.Add(theatreShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theatreShow);
        }

        // GET: TheatreShows/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.theatreShows == null)
            {
                return NotFound();
            }

            var theatreShow = await _context.theatreShows.FindAsync(id);
            if (theatreShow == null)
            {
                return NotFound();
            }
            return View(theatreShow);
        }

        // POST: TheatreShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Place,ShowDate,ImageURL")] TheatreShow theatreShow)
        {
            if (id != theatreShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theatreShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheatreShowExists(theatreShow.Id))
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
            return View(theatreShow);
        }

        // GET: TheatreShows/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.theatreShows == null)
            {
                return NotFound();
            }

            var theatreShow = await _context.theatreShows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatreShow == null)
            {
                return NotFound();
            }

            return View(theatreShow);
        }

        // POST: TheatreShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.theatreShows == null)
            {
                return Problem("Entity set 'ApplicationDbContext.theatreShows'  is null.");
            }
            var theatreShow = await _context.theatreShows.FindAsync(id);
            if (theatreShow != null)
            {
                _context.theatreShows.Remove(theatreShow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheatreShowExists(Guid id)
        {
          return (_context.theatreShows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
