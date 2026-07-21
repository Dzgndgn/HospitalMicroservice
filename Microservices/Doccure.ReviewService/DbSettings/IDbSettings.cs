namespace Doccure.ReviewService.DbSettings
{
    public interface IDbSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string Collection { get; set; }
    }
}
