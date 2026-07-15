using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;
using Doccure.BranchService.Settings;
using MongoDB.Driver;

namespace Doccure.BranchService.Services
{
    public class BranchService : IBranchService
    {
        private readonly IMongoCollection<Branch> branchCollection;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IMongoSettings settings)
        {
            _mapper = mapper;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DbName);
            branchCollection = database.GetCollection<Branch>(settings.Collection);
        }

        public async Task createBranch(CreateBranchDto createBranchDto)
        {
            var branch = _mapper.Map<Branch>(createBranchDto);
            await branchCollection.InsertOneAsync(branch);
        }

        public async Task<List<GetBranchDto>> getAllBranch()
        {
            var branches =  await branchCollection.Find(x => true).ToListAsync();
            var results =  _mapper.Map<List<GetBranchDto>>(branches);
            return results;
        }

        public async Task<GetBranchDto> getBranchByID(string id)
        {
            var branch =await branchCollection.Find(x => x.BranchId == id).FirstOrDefaultAsync();
            var result =_mapper.Map<GetBranchDto>(branch);
            return result;
        }

        public async Task RemoveBranch(string id)
        {
            var branch =await branchCollection.DeleteOneAsync(x => x.BranchId == id);
        }

        public async Task UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            var value = _mapper.Map<Branch>(updateBranchDto);
            await branchCollection.FindOneAndReplaceAsync(x => x.BranchId == updateBranchDto.BranchId, value);
        }
    }
}
