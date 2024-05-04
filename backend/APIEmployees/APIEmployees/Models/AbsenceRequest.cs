using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEmployees.Models
{
    public partial class AbsenceRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AbsenceTypeId { get; set; }
        public int StateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual AbsenceType? AbsenceType { get; set; }
        public virtual State? State { get; set; }
    }
}
