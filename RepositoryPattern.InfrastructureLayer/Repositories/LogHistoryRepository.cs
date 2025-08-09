using RepositoryPattern.DomainLayer.Entities;
using RepositoryPattern.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.InfrastructureLayer.Repositories
{
    public class LogHistoryRepository : GenericRepository<LogHistory>, ILogHistoryRepository
    {
        public LogHistoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
