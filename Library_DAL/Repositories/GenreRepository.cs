using Libriary_DAL.Data;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;

namespace Libriary_DAL.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly AppDbContext _appDbContext;

        public GenreRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

    }
}
