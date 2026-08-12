using Doccure.BranchService.Dtos;
using Doccure.BranchService.Services.RoleServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.BranchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleServices _roleService;

        public RolesController(IRoleServices roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto dto)
        {
            var result = await _roleService.CreateRole(dto);
            if(!result)
                return BadRequest("Role creation failed.");
            return Ok("Role created successfully");
        }
    }
}
