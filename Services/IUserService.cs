using Suivi_Colis_Back.DTOs;

namespace Suivi_Colis_Back.Services
{
    public interface IUserService
    {
        UserDto GetUserById(int id);
        IEnumerable<UserDto> GetAllUsers();
        void AddUser(CreateUserDto dto);
        void UpdateUser(int id, UpdateUserDto dto);
        void DeleteUser(int id);
    }
}
