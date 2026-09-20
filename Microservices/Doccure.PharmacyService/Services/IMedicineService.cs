using Doccure.PharmacyService.Dtos;

namespace Doccure.PharmacyService.Services
{
    public interface IMedicineService
    {
        Task<List<GetMedicineDto>> GetAllMedicineAsync();
        Task<GetMedicineDto> GetByIdMedicineAsync(int id);
        Task CreateMedicineAsync(CreateMedicineDto createMedicineDto);
        Task UpdateMedicineAsync(GetMedicineDto updateMedicineDto);
        Task DeleteMedicineAsync(int id);
    }
}
