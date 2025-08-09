using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DomainLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRespository DepartmentRespository { get; }
        ILogHistoryRepository LogHistoryRespository { get; }
        Task<int> CompleteAsync();
    }
}
