using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var vals = await _service.GetAllAsync();
            return Ok(vals);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var val = await _service.GetByIdAsync(id);
            return Ok(val);
        }
        [HttpPut]
        public async Task<IActionResult> update(UpdateAppointmentDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

    }
}
