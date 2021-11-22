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
    public class AllergiesController : Controller
    {
        private readonly part5dbContext _context;

        public AllergiesController(part5dbContext context)
        {
            _context = context;
        }

        // GET: Allergies
        public IActionResult Index()
        {
            var part5dbContext = _context.Allergy.Include(a => a.Patient);

            var allergiesViewModel = new AllergiesViewModel();

            if (TempData["searchKey"] != null)
            {
                allergiesViewModel.SearchAllergyname = TempData["searchKey"].ToString();

                allergiesViewModel.Allergies = part5dbContext.Where(p => p.Allergyname.Equals(allergiesViewModel.SearchAllergyname)).ToList();
            }
            else
            {
                allergiesViewModel.Allergies = part5dbContext.ToList();
            }
            return View(allergiesViewModel);
        }
        [HttpPost]
        public IActionResult Index(AllergiesViewModel allergiesViewModel)
        {
            TempData["searchKey"] = allergiesViewModel.SearchAllergyname;
            return RedirectToAction("Index");
        }
        // GET: Allergies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // GET: Allergies/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
            return View();
        }

        // POST: Allergies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,Allergyname")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", allergy.PatientId);
            return View(allergy);
        }

        // GET: Allergies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", allergy.PatientId);
            return View(allergy);
        }

        // POST: Allergies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Allergyname")] Allergy allergy)
        {
            if (id != allergy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergyExists(allergy.Id))
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
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", allergy.PatientId);
            return View(allergy);
        }

        // GET: Allergies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // POST: Allergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergy = await _context.Allergy.FindAsync(id);
            _context.Allergy.Remove(allergy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergyExists(int id)
        {
            return _context.Allergy.Any(e => e.Id == id);
        }
    }
}
