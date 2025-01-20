using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Mappers;
using Suivi_Colis_Back.Models;
using Suivi_Colis_Back.Repositories;

namespace Suivi_Colis_Back.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserMapper _mapper;

        public UserService(IUserRepository repository, IUserMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDto GetUserById(int id)
        {
            var user = _repository.GetById(id);
            return user == null ? null : _mapper.MapToDto(user);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _repository.GetAll();
            return users.Select(_mapper.MapToDto);
        }

        public void AddUser(CreateUserDto dto)
        {
            var user = _mapper.MapToEntity(dto);
            _repository.Add(user);
        }

        public void UpdateUser(int id, UpdateUserDto dto)
        {
            var user = _repository.GetById(id);
            if (user == null) return;

            _mapper.UpdateEntityFromDto(user, dto);
            _repository.Update(user);
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }
    }
}
