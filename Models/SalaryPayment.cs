namespace Employee_Payee_Tax_Calculator_MVC.Models
{
    public class SalaryPayment
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public decimal CalculatedTax { get; set; }
    }
}
