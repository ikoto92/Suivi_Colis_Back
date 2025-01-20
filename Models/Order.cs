namespace Suivi_Colis_Back.Models
{
    public enum OrderStatus
    {
        Pending,
        Preparing,
        Sent,
        Delivered,
        Canceled
    }

    public class Order
    {
        public int Id { get; set; }
        public string TrackId { get; set; }
        public OrderStatus Status { get; set; }

        // Clé étrangère pour le produit
        public int ProductId { get; set; }
        public Product Product { get; set; } 

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
