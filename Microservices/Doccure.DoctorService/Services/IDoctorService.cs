using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Services
{
    public interface IDoctorService
    {
        Task CreateDoctor(CreateDoctorDto dto);
        Task UpdateDoctor(UpdateDoctorDto dto);
        Task DeleteDoctor(string id);
        Task<GetDoctorDto> GetDoctorById(string id);
        Task<List<GetDoctorDto>> GetAllDoctors();
    }
}
