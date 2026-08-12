using AutoMapper;
using Doccure.AppointmentService.Dtos.AppointmentDetailDtos;
using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;

namespace Doccure.AppointmentService.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<Entities.Appointment,ResultsAppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Appointment,UpdateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, GetAppointmentByIdDto>().ReverseMap();

            CreateMap<AppointmentDetail, CreateAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, UpdateAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, GetByIdAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, ResultAppointmentDetailDto>().ReverseMap();
        }
    }
}
