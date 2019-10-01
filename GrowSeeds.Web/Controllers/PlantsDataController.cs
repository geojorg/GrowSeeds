using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrowSeeds.Web.Data;
using GrowSeeds.Web.Data.Entities;

namespace GrowSeeds.Web.Controllers
{
    public class PlantsDataController : Controller
    {
        private readonly DataContext _context;

        public PlantsDataController(DataContext context)
        {
            _context = context;
        }

        // GET: PlantsData
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlantsData.ToListAsync());
        }

        // GET: PlantsData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantData = await _context.PlantsData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantData == null)
            {
                return NotFound();
            }

            return View(plantData);
        }

        // GET: PlantsData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantsData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlantName,PlantDate,PlantStage,LastWater,LastFeeding,PlantMedium,PlantStatus")] PlantData plantData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantData);
        }

        // GET: PlantsData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantData = await _context.PlantsData.FindAsync(id);
            if (plantData == null)
            {
                return NotFound();
            }
            return View(plantData);
        }

        // POST: PlantsData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlantName,PlantDate,PlantStage,LastWater,LastFeeding,PlantMedium,PlantStatus")] PlantData plantData)
        {
            if (id != plantData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantDataExists(plantData.Id))
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
            return View(plantData);
        }

        // GET: PlantsData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantData = await _context.PlantsData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantData == null)
            {
                return NotFound();
            }

            return View(plantData);
        }

        // POST: PlantsData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantData = await _context.PlantsData.FindAsync(id);
            _context.PlantsData.Remove(plantData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantDataExists(int id)
        {
            return _context.PlantsData.Any(e => e.Id == id);
        }
    }
}
