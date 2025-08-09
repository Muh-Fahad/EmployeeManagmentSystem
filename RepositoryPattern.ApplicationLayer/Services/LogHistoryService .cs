using AutoMapper;
using RepositoryPattern.ApplicationLayer.DTOs;
using RepositoryPattern.ApplicationLayer.Interfaces;
using RepositoryPattern.DomainLayer.Entities;
using RepositoryPattern.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ApplicationLayer.Services
{
    public class LogHistoryService : ILogHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LogHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LogHistoryDto>> GetAllAsync()
        {
            var logs = await _unitOfWork.LogHistoryRespository.GetAllAsync();
            return _mapper.Map<IEnumerable<LogHistoryDto>>(logs);
        }

        public async Task<LogHistoryDto> AddAsync(LogHistoryDto logHistoryDto)
        {
            var logHistory = _mapper.Map<LogHistory>(logHistoryDto);
            logHistory.Timestamp = DateTime.UtcNow; 
            await _unitOfWork.LogHistoryRespository.AddAsync(logHistory);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<LogHistoryDto>(logHistory);
        }

    }
}
