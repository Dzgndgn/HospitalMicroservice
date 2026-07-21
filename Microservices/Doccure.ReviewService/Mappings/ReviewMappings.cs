using AutoMapper;
using Doccure.ReviewService.Dtos.ReviewDtos;

namespace Doccure.ReviewService.Mappings
{
    public class ReviewMappings : Profile
    {
        public ReviewMappings()
        {
            CreateMap<Entities.Review, GetByIdReviewDto>().ReverseMap();
            CreateMap<Entities.Review, ResultReviewDto>().ReverseMap();
            CreateMap<Entities.Review, CreateReviewDto>().ReverseMap();
        }
    }
}
