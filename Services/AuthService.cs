using Suivi_Colis_Back.Models;
using Suivi_Colis_Back.Repositories;

namespace Suivi_Colis_Back.Services
{
    public interface IAuthService
    {
        Utilisateur Authenticate(string email, string password);
        bool IsAuthorized(string role, string requiredRole);
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;

        public AuthService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Utilisateur Authenticate(string email, string password)
        {
            var user = _repository.GetByEmail(email);
            if (user == null || !VerifyPassword(password, user.Password))
                return null;

            return user;
        }

        public bool IsAuthorized(string role, string requiredRole)
        {
            
            return role == requiredRole || role == "Admin";
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            
            return inputPassword == hashedPassword;
        }
    }
}
