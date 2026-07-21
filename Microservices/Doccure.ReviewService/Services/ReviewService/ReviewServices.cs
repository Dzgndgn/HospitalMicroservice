using AutoMapper;
using Doccure.ReviewService.DbSettings;
using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Entities;
using MongoDB.Driver;

namespace Doccure.ReviewService.Services.ReviewService
{
    public class ReviewServices : IReviewServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Entities.Review> _reviewCollection;

        public ReviewServices(IMapper mapper,IDbSettings settings)
        {
            _mapper = mapper;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DbName);
            _reviewCollection = db.GetCollection<Entities.Review>(settings.Collection);
        }

        public async Task CreateAsync(CreateReviewDto dto)
        {
            var review = _mapper.Map<Entities.Review>(dto);
            await _reviewCollection.InsertOneAsync(review);

        }

        public async Task DeleteAsync(string id)
        {
            await _reviewCollection.DeleteOneAsync(x => x.ReviewId == id);
        }

        public async Task<List<ResultReviewDto>> GetAllReview()
        {
            var reviewList = await _reviewCollection.Find(x => true).ToListAsync();
             var dtoList =_mapper.Map<List<ResultReviewDto>>(reviewList);
            return dtoList;
        }

        public async Task<GetByIdReviewDto> getByIdReview(string id)
        {
            var review = await _reviewCollection.Find(x => x.ReviewId == id).FirstOrDefaultAsync();
            var reviewDto= _mapper.Map<GetByIdReviewDto>(review);
            return reviewDto;
        }
    }
}
