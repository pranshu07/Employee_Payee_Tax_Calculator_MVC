namespace Employee_Payee_Tax_Calculator_MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public string Phone { get; set; }

        public decimal SalaryPerAnnum { get; set; }

        public string TaxCode { get; set; }
    }
}
