using Doccure.BranchService.Dtos.BranchDtos;

namespace Doccure.BranchService.Services
{
    public interface IBranchService
    {
        Task<List<GetBranchDto>> getAllBranch();
        Task<GetBranchDto> getBranchByID(string id);
        Task createBranch(CreateBranchDto createBranchDto);
        Task UpdateBranch(UpdateBranchDto updateBranchDto);
        Task RemoveBranch(string id);

    }
}
