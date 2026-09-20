using AutoMapper;
using Doccure.PharmacyService.Dtos;
using Doccure.PharmacyService.Entities;
using System.Runtime;

namespace Doccure.PharmacyService.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<GetMedicineDto, Medicine>().ReverseMap();
            CreateMap<CreateMedicineDto, Medicine>().ReverseMap();
        }
    }
}
