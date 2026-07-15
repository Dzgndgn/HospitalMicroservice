namespace Doccure.BranchService.Settings
{
    public class MongoDbSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get ; set ; }
        public string Collection { get ; set ; }
    }
}
