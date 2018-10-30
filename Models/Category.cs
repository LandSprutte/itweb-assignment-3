using System.Collections.Generic;

namespace assignment3_db.Models
{
    public class Category
    {
        public Category()
        {
            ComponentTypeCategories = new List<ComponentTypeCategory>();
        }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentTypeCategory> ComponentTypeCategories
        {
            get; protected set;
        }
    }
}
