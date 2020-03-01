using Employee_Payee_Tax_Calculator_MVC.Data;
using Employee_Payee_Tax_Calculator_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Payee_Tax_Calculator_MVC.Controllers
{
    [Authorize]
    public class TaxTablesController : Controller
    {
        private readonly Employee_Payee_Tax_Calculator_DBContext _context;

        public TaxTablesController(Employee_Payee_Tax_Calculator_DBContext context)
        {
            _context = context;
        }

        // GET: TaxTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxTable.ToListAsync());
        }

        // GET: TaxTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxTable = await _context.TaxTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxTable == null)
            {
                return NotFound();
            }

            return View(taxTable);
        }

        // GET: TaxTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaxCode,TaxPercentage")] TaxTable taxTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxTable);
        }

        // GET: TaxTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxTable = await _context.TaxTable.FindAsync(id);
            if (taxTable == null)
            {
                return NotFound();
            }
            return View(taxTable);
        }

        // POST: TaxTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaxCode,TaxPercentage")] TaxTable taxTable)
        {
            if (id != taxTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxTableExists(taxTable.Id))
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
            return View(taxTable);
        }

        // GET: TaxTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxTable = await _context.TaxTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxTable == null)
            {
                return NotFound();
            }

            return View(taxTable);
        }

        // POST: TaxTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxTable = await _context.TaxTable.FindAsync(id);
            _context.TaxTable.Remove(taxTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxTableExists(int id)
        {
            return _context.TaxTable.Any(e => e.Id == id);
        }
    }
}
