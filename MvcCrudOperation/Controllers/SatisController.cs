using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCrudOperation.Data;
using MvcCrudOperation.Models;

namespace MvcCrudOperation.Controllers
{
    public class SatisController : Controller
    {
        private readonly AppDbContext _context;

        public SatisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Satis
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Satislar.Include(s => s.Musteri).Include(s => s.Urun);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Satis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satis = await _context.Satislar
                .Include(s => s.Musteri)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (satis == null)
            {
                return NotFound();
            }

            return View(satis);
        }

        // GET: Satis/Create
        public IActionResult Create()
        {
            ViewData["MusteriId"] = new SelectList(_context.Musteriler, "Id", "Id");
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Id");
            return View();
        }

        // POST: Satis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SatisTarihi,Miktar,ToplamTutar,MusteriId,UrunId")] Satis satis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(satis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteriler, "Id", "Id", satis.MusteriId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Id", satis.UrunId);
            return View(satis);
        }

        // GET: Satis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satis = await _context.Satislar.FindAsync(id);
            if (satis == null)
            {
                return NotFound();
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteriler, "Id", "Id", satis.MusteriId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Id", satis.UrunId);
            return View(satis);
        }

        // POST: Satis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SatisTarihi,Miktar,ToplamTutar,MusteriId,UrunId")] Satis satis)
        {
            if (id != satis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(satis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatisExists(satis.Id))
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
            ViewData["MusteriId"] = new SelectList(_context.Musteriler, "Id", "Id", satis.MusteriId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Id", satis.UrunId);
            return View(satis);
        }

        // GET: Satis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satis = await _context.Satislar
                .Include(s => s.Musteri)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (satis == null)
            {
                return NotFound();
            }

            return View(satis);
        }

        // POST: Satis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var satis = await _context.Satislar.FindAsync(id);
            if (satis != null)
            {
                _context.Satislar.Remove(satis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SatisExists(int id)
        {
            return _context.Satislar.Any(e => e.Id == id);
        }
    }
}
