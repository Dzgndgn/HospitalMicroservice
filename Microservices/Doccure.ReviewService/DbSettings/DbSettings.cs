namespace Doccure.ReviewService.DbSettings
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string Collection { get; set; }
    }
}
