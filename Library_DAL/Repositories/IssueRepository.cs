using Libriary_DAL.Data;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Repositories
{
    public class IssueRepository: GenericRepository<Issue>, IIssueRepository
    {
        private readonly AppDbContext _appDbContext;
        public IssueRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

    }
}
