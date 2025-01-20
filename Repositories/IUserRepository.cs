using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Repositories
{
    public interface IUserRepository
    {
        Utilisateur GetById(int id);
        IEnumerable<Utilisateur> GetAll();
        void Add(Utilisateur user);
        void Update(Utilisateur user);
        void Delete(int id);
        Utilisateur GetByEmail(string email);
    }
}
