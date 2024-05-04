using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIEmployees.Models
{
    public partial class State
    {
        public State()
        {
            AbsenceRequests = new HashSet<AbsenceRequest>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string State1 { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<AbsenceRequest> AbsenceRequests { get; set; }
    }
}
