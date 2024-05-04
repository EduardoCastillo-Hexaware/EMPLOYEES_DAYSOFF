using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIEmployees.Models
{
    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public virtual Employee? Employee { get; set; } = null!;
        
        public virtual Role? Role { get; set; } = null!;
    }
}
