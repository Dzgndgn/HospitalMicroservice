using AutoMapper;
using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AppointmentService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(CreateAppointmentDto dto)
        {
            var val = _mapper.Map<Appointment>(dto);
            await _context.Appointments.AddAsync(val);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Appointments.Where(x => x.AppointmentId == id).ExecuteDeleteAsync();
        }

        public async Task<List<ResultsAppointmentDto>> GetAllAsync()
        {
            var appointments = await _context.Appointments.ToListAsync();
            var map = _mapper.Map<List<ResultsAppointmentDto>>(appointments);
            return map;
        }

        public async Task<ResultsAppointmentDto> GetByIdAsync(int id)
        {
            var appointment =await _context.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);
            var map = _mapper.Map<ResultsAppointmentDto>(appointment);
            return map;
        }

        public async Task UpdateAsync(UpdateAppointmentDto dto)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == dto.AppointmentId);
            if(appointment == null)
                throw new Exception("Appointment not found");
            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Status = dto.Status;
            await _context.SaveChangesAsync();
        }
    }
}
