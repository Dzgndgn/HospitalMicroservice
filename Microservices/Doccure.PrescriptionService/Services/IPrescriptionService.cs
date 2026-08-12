using Doccure.PrescriptionService.Dtos.PrescriptionDtos;

namespace Doccure.PrescriptionService.Services
{
    public interface IPrescriptionService
    {
        public Task CreateAsync(CreatePrescriptionDto dto);
        public Task<ResultPrescriptionDto> GetByAppointmentIdAsync(int appointmentId);
        public Task<List<ResultPrescriptionDto>> GetByPatientIdAsync(string patientId);
        public Task<ResultPrescriptionDto> GetByIdAsync(int id);
    }
}
