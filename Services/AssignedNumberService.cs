using AutoMapper;
using DTOs;
using Entities.Exceptions;
using Entities;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AssignedNumberService : IAssignedNumberService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AssignedNumberService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AssignedNumberDto> CreateAsync(AssignedNumberCreateDto createDto)
        {
            var assignedNumber = _mapper.Map<AssignedNumber>(createDto);
            _repositoryManager.AssignedNumber.Create(assignedNumber);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<AssignedNumberDto>(assignedNumber);
        }

        public async Task DeleteAsync(int id)
        {
            var assignedNumber = await _repositoryManager.AssignedNumber.GetByIdAsync(id);
            if (assignedNumber == null)
            {
                throw new AssignedNumberNotFoundException(id);
            }

            _repositoryManager.AssignedNumber.Delete(assignedNumber);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<AssignedNumberDto>> GetAllAsync()
        {
            var assignedNumbers = await _repositoryManager.AssignedNumber.GetAllAsync();
            return _mapper.Map<IEnumerable<AssignedNumberDto>>(assignedNumbers);
        }

        public async Task<AssignedNumberDto> GetByIdAsync(int id)
        {
            var assignedNumber = await _repositoryManager.AssignedNumber.GetByIdAsync(id);
            return _mapper.Map<AssignedNumberDto>(assignedNumber);
        }

        public async Task<IEnumerable<AssignedNumberDto>> GetByUserPlanIdAsync(int planId)
        {
            var assignedNumbers = await _repositoryManager.AssignedNumber.GetByUserPlanIdAsync(planId);
            var assignedNumberDtos = _mapper.Map<IEnumerable<AssignedNumberDto>>(assignedNumbers);
            return assignedNumberDtos;
        }

        public async Task UpdateAsync(int id, AssignedNumberUpdateDto updateDto)
        {
            var assignedNumber = await _repositoryManager.AssignedNumber.GetByIdAsync(id);
            if (assignedNumber == null)
            {
                throw new AssignedNumberNotFoundException(id);
            }

            _mapper.Map(updateDto, assignedNumber);
            _repositoryManager.AssignedNumber.Update(assignedNumber);
            await _repositoryManager.SaveAsync();
        }
    }


}
