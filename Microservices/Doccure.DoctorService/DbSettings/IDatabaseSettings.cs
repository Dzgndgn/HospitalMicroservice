namespace Doccure.DoctorService.DbSettings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string Collection { get; set; }
    }
}
