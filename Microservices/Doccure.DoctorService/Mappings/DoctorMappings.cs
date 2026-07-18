using AutoMapper;
using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Mappings
{
    public class DoctorMappings : Profile
    {
        public DoctorMappings()
        {
            CreateMap<Entities.Doctor, CreateDoctorDto>().ReverseMap();
            CreateMap<Entities.Doctor, UpdateDoctorDto>().ReverseMap();
            CreateMap<Entities.Doctor, GetDoctorDto>().ReverseMap();
            CreateMap<Entities.Doctor, DeleteDoctorDto>().ReverseMap();
            CreateMap<Entities.Award, AwardDto>().ReverseMap();
            CreateMap<Entities.Experience, ExperienceDto>().ReverseMap();
            CreateMap<Entities.Education, EducationDto>().ReverseMap();
            CreateMap<Entities.Location, LocationDto>().ReverseMap();
        }
    }
}
