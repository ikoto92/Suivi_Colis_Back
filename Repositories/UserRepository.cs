using Suivi_Colis_Back.Data;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Utilisateur GetById(int id)
        {
            return _context.Utilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            return _context.Utilisateurs.ToList();
        }

        public void Add(Utilisateur user)
        {
            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
        }

        public void Update(Utilisateur user)
        {
            _context.Utilisateurs.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Utilisateurs.Remove(user);
                _context.SaveChanges();
            }
        }

        public Utilisateur GetByEmail(string email)
        {
            return _context.Utilisateurs.FirstOrDefault(u => u.Email == email);
        }
    }
}
