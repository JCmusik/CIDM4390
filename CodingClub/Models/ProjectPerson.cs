namespace CodingClub.Models
{
    public class ProjectPerson
    {
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}