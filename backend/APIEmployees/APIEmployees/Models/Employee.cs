using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIEmployees.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Users = new HashSet<User>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FirstLastName { get; set; } = null!;
        public string SecLastName { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public long? PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public DateTime DateOfJoin { get; set; }
        public virtual Gender? Gender { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<AbsenceRequest> AbsenceRequests { get; set; }
    }
}
