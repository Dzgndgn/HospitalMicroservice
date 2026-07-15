namespace Doccure.BranchService.Settings
{
    public interface IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string Collection { get; set; }
    }
}
