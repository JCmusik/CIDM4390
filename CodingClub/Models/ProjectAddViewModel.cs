using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingClub.Models
{
    public class ProjectAddViewModel
    {
        public int PAVID { get; set; }
        public int SelectID { get; set; }
        public Project NewProject { get; set; }
        public List<SelectListItem> MemberList { get; set; }
        public List<SelectListItem> ClientList { get; set; }

    }
}