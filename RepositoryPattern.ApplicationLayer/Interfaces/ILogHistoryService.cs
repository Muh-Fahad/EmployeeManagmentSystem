using RepositoryPattern.ApplicationLayer.DTOs;
using RepositoryPattern.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ApplicationLayer.Interfaces
{
    public interface ILogHistoryService
    {
        Task<LogHistoryDto> AddAsync(LogHistoryDto logHistoryDto);
        Task<IEnumerable<LogHistoryDto>> GetAllAsync();

    }
}
