using AutoMapper;
using Doccure.DoctorService.DbSettings;
using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Entities;
using MongoDB.Driver;

namespace Doccure.DoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctorCollection;
        private readonly IMapper _mapper;

        public DoctorService(IDatabaseSettings dbsettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(dbsettings.ConnectionString);
            var database = client.GetDatabase(dbsettings.DbName);
            _doctorCollection = database.GetCollection<Doctor>(dbsettings.Collection);
        }

        public async Task CreateDoctor(CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            await _doctorCollection.InsertOneAsync(doctor);
        }

        public async Task DeleteDoctor(string id)
        {
            await _doctorCollection.DeleteOneAsync(s => s.DoctorId == id);
        }

        public async Task<List<GetDoctorDto>> GetAllDoctors()
        {
            var allDoctors = await _doctorCollection.Find(x=> true).ToListAsync();
            var map = _mapper.Map<List<GetDoctorDto>>(allDoctors);
            return map;
        }

        public async Task<GetDoctorDto> GetDoctorById(string id)
        {
            var doctor = await _doctorCollection.Find(x=>x.DoctorId == id).FirstOrDefaultAsync();
            var map = _mapper.Map<GetDoctorDto>(doctor);
            return map;
        }

        public async Task UpdateDoctor(UpdateDoctorDto dto)
        {
            var updateValue = _mapper.Map<Doctor>(dto);
            await _doctorCollection.FindOneAndReplaceAsync(x => x.DoctorId == dto.DoctorId, updateValue);
        }
    }
}
