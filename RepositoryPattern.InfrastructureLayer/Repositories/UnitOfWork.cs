using RepositoryPattern.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.InfrastructureLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IDepartmentRespository DepartmentRespository  { get; private set; }
        public ILogHistoryRepository LogHistoryRespository { get; private set; }

    public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
            DepartmentRespository = new DepartmentRespository(_context);
            LogHistoryRespository = new LogHistoryRepository(_context);

        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> CompleteAsync() 
        {
            return await _context.SaveChangesAsync();
        }
    }
}
