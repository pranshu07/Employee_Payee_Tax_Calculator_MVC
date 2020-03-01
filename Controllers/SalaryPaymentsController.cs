using Employee_Payee_Tax_Calculator_MVC.Data;
using Employee_Payee_Tax_Calculator_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Payee_Tax_Calculator_MVC.Controllers
{
    [Authorize]
    public class SalaryPaymentsController : Controller
    {
        private readonly Employee_Payee_Tax_Calculator_DBContext _context;

        public SalaryPaymentsController(Employee_Payee_Tax_Calculator_DBContext context)
        {
            _context = context;
        }

        // GET: SalaryPayments
        public async Task<IActionResult> Index()
        {
            var employee_Payee_Tax_Calculator_DBContext = _context.SalaryPayment.Include(s => s.Employee);
            return View(await employee_Payee_Tax_Calculator_DBContext.ToListAsync());
        }

        // GET: SalaryPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryPayment = await _context.SalaryPayment
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryPayment == null)
            {
                return NotFound();
            }

            return View(salaryPayment);
        }

        // GET: SalaryPayments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            return View();
        }

        // POST: SalaryPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,EmployeeId,CalculatedTax")] SalaryPayment salaryPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", salaryPayment.EmployeeId);
            return View(salaryPayment);
        }

        // GET: SalaryPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryPayment = await _context.SalaryPayment.FindAsync(id);
            if (salaryPayment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", salaryPayment.EmployeeId);
            return View(salaryPayment);
        }

        // POST: SalaryPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,EmployeeId,CalculatedTax")] SalaryPayment salaryPayment)
        {
            if (id != salaryPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryPaymentExists(salaryPayment.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", salaryPayment.EmployeeId);
            return View(salaryPayment);
        }

        // GET: SalaryPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryPayment = await _context.SalaryPayment
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryPayment == null)
            {
                return NotFound();
            }

            return View(salaryPayment);
        }

        // POST: SalaryPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryPayment = await _context.SalaryPayment.FindAsync(id);
            _context.SalaryPayment.Remove(salaryPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryPaymentExists(int id)
        {
            return _context.SalaryPayment.Any(e => e.Id == id);
        }
    }
}
