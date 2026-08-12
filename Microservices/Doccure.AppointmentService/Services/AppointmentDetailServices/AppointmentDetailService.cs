using AutoMapper;
using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Dtos.AppointmentDetailDtos;
using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Services.AppointmentDetailServices
{
    public class AppointmentDetailService : IAppointmentDetailServices
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public AppointmentDetailService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task CreateAppointmentDetail(CreateAppointmentDetailDto dto)
        {
            var appointmentExists = await _appDbContext.Appointments.AnyAsync(a => a.AppointmentId == dto.AppointmentId);
            if (!appointmentExists)
                throw new Exception("Appointment with the given ID does not exist.");
            var val = _mapper.Map<AppointmentDetail>(dto);
            await _appDbContext.AppointmentDetails.AddAsync(val);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteAppointmentDetail(int appointmentDetailId)
        {
            await _appDbContext.AppointmentDetails.Where(x => x.AppointmentDetailId == appointmentDetailId).ExecuteDeleteAsync();
        }

        public async Task<List<ResultAppointmentDetailDto>> getAllAppointmentDetailAsync()
        {
            var details = await _appDbContext.AppointmentDetails.ToListAsync();
            var map = _mapper.Map<List<ResultAppointmentDetailDto>>(details);
            return map;
        }

        public async Task<ResultAppointmentDetailDto> getByIdAppointmentDetail(int id)
        {
            var detail = await _appDbContext.AppointmentDetails.FirstOrDefaultAsync(x => x.
            AppointmentDetailId == id);
            //if (detail == null)
            //    throw new Exception("Appointment detail with the given ID does not exist.");
            var map = _mapper.Map<ResultAppointmentDetailDto>(detail);
            return map;
        }

        public async Task UpdateAppointmnetDetail(UpdateAppointmentDetailDto dto)
        {
            var detail = await _appDbContext.AppointmentDetails.FirstOrDefaultAsync(x => x.AppointmentDetailId == dto.AppointmentDetailId);
            if (detail == null)
                throw new Exception("Appointment detail with the given ID does not exist.");
            detail.Complaint = dto.Complaint;
            detail.Notes = dto.Notes;
            detail.Diagnosis = dto.Diagnosis;
            detail.Prescription = dto.Prescription;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
