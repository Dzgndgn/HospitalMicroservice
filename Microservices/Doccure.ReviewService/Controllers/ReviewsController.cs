using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Services.ReviewService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;

        public ReviewsController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewDto dto)
        {
            await _reviewServices.CreateAsync(dto);
            return Ok("Review Created Successfully");
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var reviews = await _reviewServices.GetAllReview();
            return Ok(reviews);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>getById(string id)
        {
            var rev = await _reviewServices.getByIdReview(id);
            return Ok(rev);
        }
        
        [HttpDelete]
        public async Task<IActionResult> delete(string id)
        {
            await _reviewServices.DeleteAsync(id);
            return Ok("Review Deleted Successfully");
        }
    }
}
