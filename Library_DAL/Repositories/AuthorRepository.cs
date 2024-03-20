using Libriary_DAL.Data;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;

namespace Libriary_DAL.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

    }
}
