using System;

namespace CodingClub.Models
{
    /// <summary>
    /// A member of the Coding Club
    /// </summary>
    public class Member : Person
    {
        public int MemberID { get; set; }
        public string Role { get; set; }
        private int HoursLogged { get; set; }

        #region Methods

        public void JoinClub()
        {

        }

        public void LogHoursToProject(int hoursLogged)
        {
            HoursLogged = hoursLogged;
        }

        public void CompleteProject(Project project, int id)
        {
            if (project.ProjectID == id)
            {
                project.Completed = true;
            }

        }

        #endregion
    }
}
