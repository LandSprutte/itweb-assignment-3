namespace assignment3_db.Models
{
    public class ComponentTypeCategory
    {
        public long ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}