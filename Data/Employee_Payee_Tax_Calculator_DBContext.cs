using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employee_Payee_Tax_Calculator_MVC.Models;

namespace Employee_Payee_Tax_Calculator_MVC.Data
{
    public class Employee_Payee_Tax_Calculator_DBContext : DbContext
    {
        public Employee_Payee_Tax_Calculator_DBContext (DbContextOptions<Employee_Payee_Tax_Calculator_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee_Payee_Tax_Calculator_MVC.Models.Company> Company { get; set; }

        public DbSet<Employee_Payee_Tax_Calculator_MVC.Models.Employee> Employee { get; set; }

        public DbSet<Employee_Payee_Tax_Calculator_MVC.Models.SalaryPayment> SalaryPayment { get; set; }

        public DbSet<Employee_Payee_Tax_Calculator_MVC.Models.TaxTable> TaxTable { get; set; }
    }
}
