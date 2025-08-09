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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(string? name = null, int? departmentId = null,
                                                                    string? status = null,
                                                                    DateTime? hireDateFrom = null,
                                                                    DateTime? hireDateTo = null,
                                                                    string? sortBy = null,
                                                                    bool isDescending = false)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllWithDepartmentAsync(name,departmentId,status,hireDateFrom,hireDateTo,sortBy,isDescending);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdWithDepartmentAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> AddAsync(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateAsync(int id, CreateEmployeeDto employeeDto)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            _mapper.Map(employeeDto, employee);
            _unitOfWork.EmployeeRepository.Update(employee);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null) return false;
            _unitOfWork.EmployeeRepository.Remove(employee);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}