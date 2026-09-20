using Doccure.WebUI.Dtos.BranchDtos;
using Doccure.WebUI.Services.BranchServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto dto)
        {
            await _branchService.CreateBranch(dto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var branches = await _branchService.GetAllBranch();
                return View(branches);
            }
            catch(Exception ex) when (ex.Message== "401")
            {
                return RedirectToAction("Unauthorized401", "Error");
            }
            catch(Exception ex) when (ex.Message == "403")
            {
                return RedirectToAction("Forbidden403", "Error");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteBranch(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBranch()
        {
            return View();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto dto)
        {
            await _branchService.UpdateBranch(dto);
            return RedirectToAction("Index");
        }
    }
}
