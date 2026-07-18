using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.DoctorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctor()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _doctorService.DeleteDoctor(id);
            return Ok("Doctor removed succesfully");
        }
        [HttpPost]
        public async Task<IActionResult> addDoctor(CreateDoctorDto dto)
        {
            await _doctorService.CreateDoctor(dto);
            return Ok("Doctor added successfully");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getDoctorById(string id)
        {
           var doctor =  await _doctorService.GetDoctorById(id);
            return Ok(doctor);
        }
        [HttpPut]
        public async Task<IActionResult> updateDoctor(UpdateDoctorDto dto)
        {
            await _doctorService.UpdateDoctor(dto);
            return Ok("Doctor updated successfully");
        }
    }
}
