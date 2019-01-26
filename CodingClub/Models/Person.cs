using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingClub.Models
{
    /// <summary>
    /// Abstract class for shared properties between Client and Member
    /// </summary>
    public abstract class Person
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public ICollection<ProjectPerson> Projects { get; set; }

        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
}