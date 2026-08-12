using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.BranchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllBranch()
        {
            var branches =await _branchService.getAllBranch();
            return Ok(branches);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto dto)
        {
            await _branchService.createBranch(dto);
            return Ok("Branch Created Successfully");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveBranch(string id)
        {
             await _branchService.RemoveBranch(id);
            return Ok("Branch Deleted Successfully");
        }
        [HttpGet("id")]
        public async Task<IActionResult> getBranchById(string id)
        {
            var branch =await _branchService.getBranchByID(id);
            return Ok(branch);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBranchDto dto)
        {
            await _branchService.UpdateBranch(dto);
            return Ok("Branch updated successfully");
        }
    }
}
