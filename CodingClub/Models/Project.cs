using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingClub.Models
{
    /// <summary>
    /// A project for Members and Clients to collaborate on
    /// </summary>
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Begin Date")]
        public DateTime BeginDate { get; set; }
        [Display(Name = "Finish Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Total Hours")]
        public int TotalHours { get; set; }
        public ICollection<ProjectPerson> Persons { get; set; }
    }
}