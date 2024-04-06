using DTOs;

namespace Service.Contracts
{
    public interface IAssignedNumberService
    {
        Task<IEnumerable<AssignedNumberDto>> GetAllAsync();
        Task<AssignedNumberDto> GetByIdAsync(int id);
        Task<AssignedNumberDto> CreateAsync(AssignedNumberCreateDto createDto);
        Task UpdateAsync(int id, AssignedNumberUpdateDto updateDto);
        Task DeleteAsync(int id);

        Task<IEnumerable<AssignedNumberDto>> GetByUserPlanIdAsync(int planId);
    }

}
