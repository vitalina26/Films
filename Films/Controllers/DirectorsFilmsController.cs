using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppDirectors.Modails;

namespace WebAppDirectors.Controllers
{
    public class DirectorsFilmsController : Controller
    {
        private readonly Lab2LibaryContext _context;

        public DirectorsFilmsController(Lab2LibaryContext context)
        {
            _context = context;
        }

        // GET: DirectorsFilms
        public async Task<IActionResult> Index()
        {
            var lab2LibaryContext = _context.DirectorsFilms.Include(d => d.Director).Include(d => d.Film);
            return View(await lab2LibaryContext.ToListAsync());
        }

        // GET: DirectorsFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorsFilms = await _context.DirectorsFilms
                .Include(d => d.Director)
                .Include(d => d.Film)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directorsFilms == null)
            {
                return NotFound();
            }

            return View(directorsFilms);
        }

        // GET: DirectorsFilms/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id");
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Id");
            return View();
        }

        // POST: DirectorsFilms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmId,DirectorId")] DirectorsFilms directorsFilms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorsFilms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id", directorsFilms.DirectorId);
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Id", directorsFilms.FilmId);
            return View(directorsFilms);
        }

        // GET: DirectorsFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorsFilms = await _context.DirectorsFilms.FindAsync(id);
            if (directorsFilms == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id", directorsFilms.DirectorId);
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Id", directorsFilms.FilmId);
            return View(directorsFilms);
        }

        // POST: DirectorsFilms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmId,DirectorId")] DirectorsFilms directorsFilms)
        {
            if (id != directorsFilms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directorsFilms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorsFilmsExists(directorsFilms.Id))
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
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id", directorsFilms.DirectorId);
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Id", directorsFilms.FilmId);
            return View(directorsFilms);
        }

        // GET: DirectorsFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorsFilms = await _context.DirectorsFilms
                .Include(d => d.Director)
                .Include(d => d.Film)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directorsFilms == null)
            {
                return NotFound();
            }

            return View(directorsFilms);
        }

        // POST: DirectorsFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directorsFilms = await _context.DirectorsFilms.FindAsync(id);
            _context.DirectorsFilms.Remove(directorsFilms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorsFilmsExists(int id)
        {
            return _context.DirectorsFilms.Any(e => e.Id == id);
        }
    }
}
