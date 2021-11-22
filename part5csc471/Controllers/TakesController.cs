using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using part5csc471.Entities;
using part5csc471.Models;

namespace part5csc471.Controllers
{
    public class TakesController : Controller
    {
        private readonly part5dbContext _context;

        public TakesController(part5dbContext context)
        {
            _context = context;
        }

        // GET: Takes
        public IActionResult Index()
        {
            var part5dbContext = _context.Takes.Include(t => t.Patient).Include(t => t.ScientNameNavigation).Include(t => t.SiteNameNavigation);

            var viewModel = new TakesViewModel();

            if (TempData["searchKey"] != null)
            {
                viewModel.SearchSiteName = TempData["searchKey"].ToString();

                viewModel.Takes = part5dbContext.Where(p => p.SiteName.Equals(TempData["searchKey"].ToString())).ToList();
            }
            else
            {
                viewModel.Takes = part5dbContext.ToList();
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(TakesViewModel viewModel)
        {
            TempData["searchKey"] = viewModel.SearchSiteName;
            return RedirectToAction("Index");
        }

        // GET: Takes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takes = await _context.Takes
                .Include(t => t.Patient)
                .Include(t => t.ScientNameNavigation)
                .Include(t => t.SiteNameNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (takes == null)
            {
                return NotFound();
            }

            return View(takes);
        }

        // GET: Takes/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
            ViewData["ScientName"] = new SelectList(_context.Vaccine, "ScientName", "ScientName");
            ViewData["SiteName"] = new SelectList(_context.VaccinationSite, "Name", "Name");
            return View();
        }

        // POST: Takes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,SiteName,ScientName")] Takes takes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(takes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", takes.PatientId);
            ViewData["ScientName"] = new SelectList(_context.Vaccine, "ScientName", "ScientName", takes.ScientName);
            ViewData["SiteName"] = new SelectList(_context.VaccinationSite, "Name", "Name", takes.SiteName);
            return View(takes);
        }

        // GET: Takes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takes = await _context.Takes.FindAsync(id);
            if (takes == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", takes.PatientId);
            ViewData["ScientName"] = new SelectList(_context.Vaccine, "ScientName", "ScientName", takes.ScientName);
            ViewData["SiteName"] = new SelectList(_context.VaccinationSite, "Name", "Name", takes.SiteName);
            return View(takes);
        }

        // POST: Takes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,SiteName,ScientName")] Takes takes)
        {
            if (id != takes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(takes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TakesExists(takes.Id))
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
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", takes.PatientId);
            ViewData["ScientName"] = new SelectList(_context.Vaccine, "ScientName", "ScientName", takes.ScientName);
            ViewData["SiteName"] = new SelectList(_context.VaccinationSite, "Name", "Name", takes.SiteName);
            return View(takes);
        }

        // GET: Takes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takes = await _context.Takes
                .Include(t => t.Patient)
                .Include(t => t.ScientNameNavigation)
                .Include(t => t.SiteNameNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (takes == null)
            {
                return NotFound();
            }

            return View(takes);
        }

        // POST: Takes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var takes = await _context.Takes.FindAsync(id);
            _context.Takes.Remove(takes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TakesExists(int id)
        {
            return _context.Takes.Any(e => e.Id == id);
        }
    }
}
