using MongoDB.Bson.Serialization.Attributes;

namespace Doccure.BranchService.Entities
{
    public class Branch
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BranchId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BranchName { get; set; }
        public bool Status { get; set; }
    }
}
