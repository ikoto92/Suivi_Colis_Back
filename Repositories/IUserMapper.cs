using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Mappers
{
    public interface IUserMapper
    {
        UserDto MapToDto(Utilisateur user);
        Utilisateur MapToEntity(CreateUserDto dto);
        void UpdateEntityFromDto(Utilisateur user, UpdateUserDto dto);
    }
}
