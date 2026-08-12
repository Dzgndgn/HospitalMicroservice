using Doccure.BranchService.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Doccure.BranchService.Services.RoleServices
{
    public class RoleService : IRoleServices
    {
        private readonly RoleManager<IdentityRole>? _roleManager;

        public RoleService(RoleManager<IdentityRole>? roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRole(CreateRoleDto dto)
        {
            if (await _roleManager.RoleExistsAsync(dto.RoleName))
                return false;
            var role = new IdentityRole
            {
                Name = dto.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }
    }
}
