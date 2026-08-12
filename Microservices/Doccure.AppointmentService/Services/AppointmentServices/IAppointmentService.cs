using Doccure.AppointmentService.Dtos.AppointmentDtos;

namespace Doccure.AppointmentService.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task CreateAsync(CreateAppointmentDto dto);
        Task UpdateAsync(UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        Task<List<ResultsAppointmentDto>> GetAllAsync();
        Task<ResultsAppointmentDto> GetByIdAsync(int id);
    }
}
