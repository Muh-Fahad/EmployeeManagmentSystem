using RepositoryPattern.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DomainLayer.Interfaces
{
    public interface ILogHistoryRepository : IGenericRepository<LogHistory>
    {
    }
}
