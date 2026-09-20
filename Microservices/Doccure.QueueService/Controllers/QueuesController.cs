using Doccure.QueueService.Context;
using Doccure.QueueService.Entities;
using Doccure.QueueService.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Doccure.QueueService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private readonly QContext _context;
        private readonly IHubContext<QueueHub> _hubContext;

        public QueuesController(QContext context, IHubContext<QueueHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> getQueue()
        {
            var values = await _context.Queues.OrderBy(x => x.QueueNumber).ToListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> createQueue(Doccure.QueueService.Entities.Queue queue)
        {
            await _context.Queues.AddAsync(queue);
            await _context.SaveChangesAsync();
            return Ok("Queue created successfully");
        }
        [HttpPost("call/{id}")]
         public async Task<IActionResult> callQueue(int id)
          {
              var patient = await _context.Queues.FindAsync(id);
              if(patient == null)
                  return NotFound("Patient not found");
            var calleds = await _context.Queues.Where(x => x.Status == "Called" && x.QueueId != id).ToListAsync();
            foreach (var item in calleds)
            {
                item.Status = "Completed";   
            }
            patient.Status = "Called";
              await _context.SaveChangesAsync();
              await _hubContext.Clients.All.SendAsync(
                  "PatientCalled",
                  patient.QueueNumber,
                  patient.PatientName,
                  patient.BranchName,
                  patient.AppointmentTime
                  );
              return Ok("Patient called");
          }
       
        [HttpGet("current")]
        public async Task<IActionResult> getCurentQueue()
        {
            var current = await _context.Queues.Where(x => x.Status == "Called").OrderBy(x => x.QueueNumber).FirstOrDefaultAsync();
            if(current == null)
                return NotFound("No patient is currently being called");
            return Ok(current);
        }
    }
}
