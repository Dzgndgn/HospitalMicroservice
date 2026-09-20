using Doccure.PatientService.Dtos;

namespace Doccure.PatientService.Services
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatientAsync();
    }
}
