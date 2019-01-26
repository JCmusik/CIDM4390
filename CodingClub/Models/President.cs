using System;

namespace CodingClub.Models
{
    /// <summary>
    /// President of the Coding Club
    /// </summary>
    public class President : Member
    {

        #region Methods

        public void CreateProject()
        {
            var project = new Project();
        }

        #endregion
    }
}
