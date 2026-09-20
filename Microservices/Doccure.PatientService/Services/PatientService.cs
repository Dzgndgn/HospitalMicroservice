using AutoMapper;
using Doccure.PatientService.Context;
using Doccure.PatientService.Dtos;
using Doccure.PatientService.Dtos.AppointmentDtos;
using Doccure.PatientService.Dtos.BranchDtos;
using Doccure.PatientService.Dtos.DoctorDtos;
using Doccure.PatientService.Dtos.IdentityDto;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Services
{
    public class PatientService : IPatientService
    {
        private readonly PContext _context;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public PatientService(PContext context, HttpClient httpClient, IMapper mapper)
        {
            _context = context;
            _httpClient = httpClient;
            _mapper = mapper;
        }
        //user ı alıp sonra  son appointment oradan doktor ı alıp branch ı alıp dto ya ekleyeceğiz
        public async Task<List<PatientDto>> GetAllPatientAsync()
        {
            var patientsWithoutDoctorAndBranch = await _context.Patients.ToListAsync();
            var map = _mapper.Map<List<PatientDto>>(patientsWithoutDoctorAndBranch);
            var patientsWithDoctorAndBranch = new List<PatientDto>();
            foreach (var item in map)
            {
                var identityUser =
                await _httpClient.GetFromJsonAsync<UserDto>(
                    $"https://localhost:7078/api/Users/{item.PatientId}");
                var lastAppointment = await _httpClient.GetFromJsonAsync<LastAppointmentDto>(
                        $"https://localhost:7100/api/AppointmentlastAppointment/{item.PatientId}");
                var doctorDto = await _httpClient.GetFromJsonAsync<GetDoctorDto>(
                    $"https://localhost:7100/api/Doctor/{lastAppointment.DoctorId}"
                    );
                var branch = await _httpClient.GetFromJsonAsync<BranchDto>(
                    $"https://localhost:7130/api/Branch/{doctorDto.BranchId}"
                    );
                var patientDto = new PatientDto
                {
                    PatientId = item.PatientId,
                    AppUserId = item.AppUserId,
                    TcKimlikNo = item.TcKimlikNo,
                    InsuranceType = item.InsuranceType,
                    CreatedDate = item.CreatedDate,
                    Status = item.Status,

                    Name = identityUser.Name,
                    Surname = identityUser.Surname,
                    FullName = $"{identityUser.Name} {identityUser.Surname}",
                    Email = identityUser.Email,
                    PhoneNumber = identityUser.PhoneNumber,
                    Gender = identityUser.Gender,
                    BirthDate = identityUser.Birthdate,
                    BloodGroup = identityUser.BloodGroup,
                    ImageUrl = identityUser.ImageUrl,
                    City = identityUser.City,
                    Address = identityUser.Address,

                    LastVisitDate = lastAppointment.AppointmentDate,
                    CurrentDiagnosis = lastAppointment.Diagnosis,

                    DoctorId = doctorDto.DoctorId,
                    DoctorName = $"{doctorDto.Name} {doctorDto.Surname}",

                    BranchId = branch.BranchId,
                    BranchName = branch.BranchName
                };
                patientsWithDoctorAndBranch.Add(patientDto);  
            }
            return patientsWithDoctorAndBranch;
        }
    }
}
