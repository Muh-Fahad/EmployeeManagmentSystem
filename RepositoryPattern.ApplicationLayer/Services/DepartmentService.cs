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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _unitOfWork.DepartmentRespository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            await _unitOfWork.DepartmentRespository.AddAsync(department);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<DepartmentDto>(department);
        }
    }
}

