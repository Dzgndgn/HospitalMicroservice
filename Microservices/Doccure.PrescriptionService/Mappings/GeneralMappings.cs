using AutoMapper;
using Doccure.PrescriptionService.Dtos.PrescriptionDtos;
using Doccure.PrescriptionService.Entitities;

namespace Doccure.PrescriptionService.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<Prescription, ResultPrescriptionDto>().ReverseMap();
            CreateMap<CreatePrescriptionDto, Prescription>().ReverseMap();
            CreateMap<PrescriptionItem, PrescriptionItemDto>().ReverseMap();
        }
    }
}
