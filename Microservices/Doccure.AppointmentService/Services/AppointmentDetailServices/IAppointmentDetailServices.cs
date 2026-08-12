using Doccure.AppointmentService.Dtos.AppointmentDetailDtos;

namespace Doccure.AppointmentService.Services.AppointmentDetailServices
{
    public interface IAppointmentDetailServices
    {
        Task<List<ResultAppointmentDetailDto>>getAllAppointmentDetailAsync();
        Task CreateAppointmentDetail(CreateAppointmentDetailDto dto);
        Task UpdateAppointmnetDetail(UpdateAppointmentDetailDto dto);
        Task DeleteAppointmentDetail(int appointmentDetailId);
        Task<ResultAppointmentDetailDto> getByIdAppointmentDetail(int  id);
    }
}
