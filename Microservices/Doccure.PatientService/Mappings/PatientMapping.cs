using AutoMapper;
using Doccure.PatientService.Entities;

namespace Doccure.PatientService.Mappings
{
    public class PatientMapping :Profile
    {
        public PatientMapping()
        {
            CreateMap<Patient, Dtos.PatientDto>().ReverseMap();
        }
    }
}
