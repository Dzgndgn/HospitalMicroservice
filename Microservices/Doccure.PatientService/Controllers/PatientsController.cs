using Doccure.PatientService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllPatientAsync()
        {
            var patients = await patientService.GetAllPatientAsync();
            if (patients == null)
                return NotFound();
            return Ok(patients);

        }
    }
}
