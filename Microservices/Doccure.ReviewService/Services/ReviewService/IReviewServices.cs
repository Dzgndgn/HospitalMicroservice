using Doccure.ReviewService.Dtos.ReviewDtos;

namespace Doccure.ReviewService.Services.ReviewService
{
    public interface IReviewServices
    {
        Task<GetByIdReviewDto> getByIdReview(string id);
        Task DeleteAsync(string id);
        Task CreateAsync(CreateReviewDto dto);
        Task<List<ResultReviewDto>> GetAllReview();


    }
}
