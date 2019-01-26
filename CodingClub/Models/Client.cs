using System.Collections.Generic;

namespace CodingClub.Models
{
    /// <summary>
    /// A client who provides a project to the Coding Club members
    /// </summary>
    public class Client : Person
    {
        public int ClientID { get; set; }
        public string PaymentMethod { get; set; }

        #region Methods

        public void RejectProposal(Project project, int id)
        {
            if (project.ProjectID == id)
            {
                project.Initiate = false;
            }
        }

        public void AcceptProposal(Project project, int id)
        {
            if (project.ProjectID == id)
            {
                project.Initiate = true;
            }
        }

        public void MakePayment(Project project, int id, decimal amount)
        {
            if (project.ProjectID == id)
            {
                project.Price -= project.Price - amount;
            }
        }

        #endregion
    }
}