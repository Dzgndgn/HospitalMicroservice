using Doccure.BranchService.Dtos;

namespace Doccure.BranchService.Services.RoleServices
{
    public interface IRoleServices
    {
        Task<bool> CreateRole(CreateRoleDto dto);
    }
}
