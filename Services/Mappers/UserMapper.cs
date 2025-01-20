using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserDto MapToDto(Utilisateur user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        public Utilisateur MapToEntity(CreateUserDto dto)
        {
            return new Utilisateur
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = HashPassword(dto.Password),
                Role = dto.Role
            };
        }

        public void UpdateEntityFromDto(Utilisateur user, UpdateUserDto dto)
        {
            user.Name = dto.Name ?? user.Name;
            user.Email = dto.Email ?? user.Email;
            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.Password = HashPassword(dto.Password);
            }
            user.Role = dto.Role ?? user.Role;
        }

        private string HashPassword(string password)
        {
            // Implémentez ici un vrai système de hachage pour la sécurité (par exemple, BCrypt)
            return password; // À remplacer par un vrai hashage sécurisé
        }
    }
}
