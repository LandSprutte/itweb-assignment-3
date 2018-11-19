using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Remotion.Linq.Clauses;

namespace assignment3_db.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRoles UserRole { get; set; }
        
    }

    public enum UserRoles
    {
        BasicUser,
        AdminUser
    }
}
