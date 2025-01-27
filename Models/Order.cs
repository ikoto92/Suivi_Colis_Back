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

        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Remplace Customer par une référence à Utilisateur
        public int CustomerId { get; set; }
        public Utilisateur Customer { get; set; } // Un client est un utilisateur avec Role = Client
    }
}
