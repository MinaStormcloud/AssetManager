using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManager.Data;
using AssetManager.Models;

namespace AssetManager.Controllers
{
    public class DevicesController : Controller
    {
        private readonly AssetManagerContext _context;

        public DevicesController(AssetManagerContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Device.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .FirstOrDefaultAsync(m => m.ID == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Brand,Model,PurchaseDate,PriceCrowns,PriceEuros,PriceDollars,PricePounds,Type,Office")] Device device)
        {
            if (ModelState.IsValid)
            {
                device.PriceEuros = ((float)(0.087 * device.PriceCrowns));
                device.PriceDollars = ((float)(0.093 * device.PriceCrowns));
                device.PricePounds = ((float)(0.074 * device.PriceCrowns));
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Brand,Model,PurchaseDate,PriceCrowns,PriceEuros,PriceDollars,PricePounds,Type,Office")] Device device)
        {
            if (id != device.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    device.PriceEuros = ((float)(0.087 * device.PriceCrowns));
                    device.PriceDollars = ((float)(0.093 * device.PriceCrowns));
                    device.PricePounds = ((float)(0.074 * device.PriceCrowns));
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.ID))
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
            return View(device);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .FirstOrDefaultAsync(m => m.ID == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device != null)
            {
                _context.Device.Remove(device);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }			
		
		[HttpPost]
        public IActionResult Results(string option, string search)
        {
            if (option == "ID")
            {
                return View(_context.Device.Where(x => x.ID.ToString().Equals(search) || search == null).ToList());
            }
            else if (option == "Brand")
            {
                return View(_context.Device.Where(x => x.Brand.Contains(search) || search == null).ToList());
            }
            else if (option == "Model")
            {
                return View(_context.Device.Where(x => x.Model.Contains(search) || search == null).ToList());
            }
            else if (option == "PurchaseDate")
            {
                return View(_context.Device.Where(x => x.PurchaseDate.ToString().Contains(search) || search == null).ToList());
            }
			else if (option == "Type")
            {
                return View(_context.Device.Where(x => x.Type.Contains(search) || search == null).ToList());
            }
            else if (option == "Office")
            {
                return View(_context.Device.Where(x => x.Office.Contains(search) || search == null).ToList());
            }
            else if (option == "PriceCrowns")
            {
                return View(_context.Device.Where(x => x.PriceCrowns.ToString().Contains(search) || search == null).ToList());
            }
			else if (option == "PriceDollars")
            {
                return View(_context.Device.Where(x => x.PriceDollars.ToString().Contains(search) || search == null).ToList());
            }
			else if (option == "PriceEuros")
            {
                return View(_context.Device.Where(x => x.PriceEuros.ToString().Contains(search) || search == null).ToList());
            }			
            else
            {
                return View(_context.Device.Where(x => x.PricePounds.ToString().Contains(search) || search == null).ToList());
            }
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.ID == id);
        }
    }
}
