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
    public class VaccinationSitesController : Controller
    {
        private readonly part5dbContext _context;

        public VaccinationSitesController(part5dbContext context)
        {
            _context = context;
        }

        // GET: VaccinationSites
        public IActionResult Index()
        {

            var viewModel = new VaccinationSitesViewModel();

            if (TempData["searchKey"] != null)
            {
                viewModel.SearchName = TempData["searchKey"].ToString();

                viewModel.VaccinationSites = _context.VaccinationSite.Where(p => p.Name.Equals(TempData["searchKey"].ToString())).ToList();
            }
            else
            {
                viewModel.VaccinationSites = _context.VaccinationSite.ToList();
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(VaccinationSitesViewModel viewModel)
        {
            TempData["searchKey"] = viewModel.SearchName;
            return RedirectToAction("Index");
        }

        // GET: VaccinationSites/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationSite = await _context.VaccinationSite
                .FirstOrDefaultAsync(m => m.Name == id);
            if (vaccinationSite == null)
            {
                return NotFound();
            }

            return View(vaccinationSite);
        }

        // GET: VaccinationSites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationSites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,AddrStreet,AddrCity,AddrState,AddrZip")] VaccinationSite vaccinationSite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccinationSite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationSite);
        }

        // GET: VaccinationSites/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationSite = await _context.VaccinationSite.FindAsync(id);
            if (vaccinationSite == null)
            {
                return NotFound();
            }
            return View(vaccinationSite);
        }

        // POST: VaccinationSites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,AddrStreet,AddrCity,AddrState,AddrZip")] VaccinationSite vaccinationSite)
        {
            if (id != vaccinationSite.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccinationSite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationSiteExists(vaccinationSite.Name))
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
            return View(vaccinationSite);
        }

        // GET: VaccinationSites/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationSite = await _context.VaccinationSite
                .FirstOrDefaultAsync(m => m.Name == id);
            if (vaccinationSite == null)
            {
                return NotFound();
            }

            return View(vaccinationSite);
        }

        // POST: VaccinationSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vaccinationSite = await _context.VaccinationSite.FindAsync(id);
            _context.VaccinationSite.Remove(vaccinationSite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationSiteExists(string id)
        {
            return _context.VaccinationSite.Any(e => e.Name == id);
        }
    }
}
