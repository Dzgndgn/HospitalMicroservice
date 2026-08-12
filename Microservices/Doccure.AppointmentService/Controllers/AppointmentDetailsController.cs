using Doccure.AppointmentService.Dtos.AppointmentDetailDtos;
using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Services.AppointmentDetailServices;
using Doccure.AppointmentService.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly IAppointmentDetailServices _service;

        public AppointmentDetailsController(IAppointmentDetailServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vals = await _service.getAllAppointmentDetailAsync();
            return Ok(vals);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAppointmentDetail(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var val = await _service.getByIdAppointmentDetail(id);
            return Ok(val);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDetailDto dto)
        {
            await _service.CreateAppointmentDetail(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDetailDto dto)
        {
            await _service.UpdateAppointmnetDetail(dto);
            return Ok();
        }
    }
}
