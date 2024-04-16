using DTOs;

namespace Service.Contracts
{
    public interface IAssignedNumberService
    {
        Task<IEnumerable<AssignedNumberDto>> GetAssignedNumbersByUserId(int userId);
    }

}
