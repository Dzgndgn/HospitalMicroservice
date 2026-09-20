using Doccure.WebUI.Dtos.BranchDtos;

namespace Doccure.WebUI.Services.BranchServices
{
    public interface IBranchService
    {
        Task CreateBranch(CreateBranchDto dto);
        Task UpdateBranch(UpdateBranchDto dto);
        Task DeleteBranch(string id);
        Task<GetByIdBranchDto> GetByIdBranch(string id);
        Task<List<ResultBranchDto>> GetAllBranch();

    }
}
