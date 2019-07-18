using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartAC.Data;
using SmartAC.Models;

namespace SmartAC.Controllers
{
    public class DataReadingsController : Controller
    {
        private readonly DeviceContext _context;

        public DataReadingsController(DeviceContext context)
        {
            _context = context;
        }

        // GET: DataReadings
        public async Task<IActionResult> Index(Guid? id)
        {
            var dataReading = from d in _context.DataReadings select d;

            if (id == null)
            {
                dataReading = _context.DataReadings.Where(m => m.DeviceId == id);

            }

            if (dataReading == null)
            {
                return NotFound();
            }

            return View(await dataReading.ToListAsync());
        }

        // GET: DataReadings
        public async Task<IActionResult> Index2()
        {
            return View(await _context.DataReadings.ToListAsync());
        }

        // GET: DataReadings/Details/5
        public async Task<IActionResult> DetailsbyId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataReading = await _context.DataReadings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataReading == null)
            {
                return NotFound();
            }

            return View(dataReading);
        }

        // GET: DataReadings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataReadings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,SensorId,Temperature,Humidity,CarbonMonoxideLevel,Status,ReadingDate")] DataReading dataReading)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataReading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataReading);
        }

        // GET: DataReadings/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataReading = await _context.DataReadings.FindAsync(id);
            if (dataReading == null)
            {
                return NotFound();
            }
            return View(dataReading);
        }

        // POST: DataReadings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DeviceId,SensorId,Temperature,Humidity,CarbonMonoxideLevel,Status,ReadingDate")] DataReading dataReading)
        {
            if (id != dataReading.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataReading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataReadingExists(dataReading.Id))
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
            return View(dataReading);
        }

        // GET: DataReadings/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataReading = await _context.DataReadings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataReading == null)
            {
                return NotFound();
            }

            return View(dataReading);
        }

        // POST: DataReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dataReading = await _context.DataReadings.FindAsync(id);
            _context.DataReadings.Remove(dataReading);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataReadingExists(long id)
        {
            return _context.DataReadings.Any(e => e.Id == id);
        }
    }
}
