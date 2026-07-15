using AutoMapper;
using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Entities;

namespace Doccure.BranchService.Mapper
{
    public class BranchDtoMappings : Profile
    {
        public BranchDtoMappings()
        {
            CreateMap<Branch,CreateBranchDto>().ReverseMap();
            CreateMap<Branch,UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchDto>().ReverseMap();
            CreateMap<Branch,DeleteBranchDto>().ReverseMap();
        }
    }
}
