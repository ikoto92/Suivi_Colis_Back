namespace Suivi_Colis_Back.Models
{
    public enum UserRole
    {
        Admin,
        Client
    }

    public class Utilisateur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } // ⚠️ Considère de la hacher pour plus de sécurité.
        public string Email { get; set; }
        public UserRole Role { get; set; } // Utilisation de l'enum pour les rôles.
    }
}
