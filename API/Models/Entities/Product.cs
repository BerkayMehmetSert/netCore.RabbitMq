using API.Models.Common;

namespace API.Models.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
