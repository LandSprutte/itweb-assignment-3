using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using assignment3_db.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment3_db.ViewModels 
{
    public class CategoryViewModel 
    {
        public CategoryViewModel() {
            SelectedComponentTypes = new List<string>();
        }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public List<string> SelectedComponentTypes { get; set; }
        public MultiSelectList ComponentTypes { get; set; }
        public List<ComponentType> DisplayComponentTypes {get; set;}
    }
}