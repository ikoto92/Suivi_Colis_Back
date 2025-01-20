namespace Suivi_Colis_Back.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Order order { get; set; }
    }
}
