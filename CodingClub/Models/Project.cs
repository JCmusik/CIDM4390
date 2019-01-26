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
        [Display(Name = "Project ID")]
        public int ProjectID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Hours Logged")]
        public int HoursLogged { get; set; }
        public bool Completed { get; set; } = false;
        public bool Initiate { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProjectPerson> Persons { get; set; }
    }
}