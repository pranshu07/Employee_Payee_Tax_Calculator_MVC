namespace Employee_Payee_Tax_Calculator_MVC.Models
{
    public class TaxTable
    {

        public int Id { get; set; }
        public string TaxCode { get; set; }

        public decimal TaxPercentage { get; set; }

    }
}
