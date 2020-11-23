using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace planning.Models
{
    public class Incident
    {

        public int IncidentId { get; set; }
      
        [Required]
        public int IncidentNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PlannedFor { get; set; }

        public String Client { get; set; }
        public String Description { get; set; }
        public int PriorityId { get; set; }
        public String Priority { get; set; }
        public int UserId { get; set; }
        public String User { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Action")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OpenedDate { get; set; }

        public bool Done { get; set; }

        [DataType(DataType.Text)]
        public String Note { get; set; }
        public String Status { get; set; }
    }
}