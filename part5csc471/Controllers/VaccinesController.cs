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
    public class VaccinesController : Controller
    {
        private readonly part5dbContext _context;

        public VaccinesController(part5dbContext context)
        {
            _context = context;
        }

        // GET: Vaccines
        public IActionResult Index()
        {

            var viewModel = new VaccinesViewModel();

            if (TempData["searchKey"] != null)
            {
                viewModel.SearchScientName = TempData["searchKey"].ToString();

                viewModel.Vaccines = _context.Vaccine.Where(p => p.ScientName.Equals(TempData["searchKey"].ToString())).ToList();
            }
            else
            {
                viewModel.Vaccines = _context.Vaccine.ToList();
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(VaccinesViewModel viewModel)
        {
            TempData["searchKey"] = viewModel.SearchScientName;
            return RedirectToAction("Index");
        }
        // GET: Vaccines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine
                .FirstOrDefaultAsync(m => m.ScientName == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // GET: Vaccines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaccines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScientName,Dissease,NoDoses")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccine);
        }

        // GET: Vaccines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ScientName,Dissease,NoDoses")] Vaccine vaccine)
        {
            if (id != vaccine.ScientName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineExists(vaccine.ScientName))
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
            return View(vaccine);
        }

        // GET: Vaccines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine
                .FirstOrDefaultAsync(m => m.ScientName == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // POST: Vaccines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vaccine = await _context.Vaccine.FindAsync(id);
            _context.Vaccine.Remove(vaccine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineExists(string id)
        {
            return _context.Vaccine.Any(e => e.ScientName == id);
        }
    }
}
