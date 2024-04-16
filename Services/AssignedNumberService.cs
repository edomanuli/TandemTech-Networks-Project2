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

        public async Task<IEnumerable<AssignedNumberDto>> GetAssignedNumbersByUserId(int userId)
        {
            var assignedNumbers = await _repositoryManager.AssignedNumber.GetAssignedNumbersByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<AssignedNumberDto>>(assignedNumbers);
        }
    }


}
