using System.Linq;
using CodingClub.Models;

namespace CodingClub.Logic
{
    public interface ISorting
    {
        IQueryable<Person> Sort(AppDbContext db, string sortOrder, string type);
        ProjectDetailViewModel ProjectJoinMembersClients(AppDbContext db, Project project);
        ProjectDetailViewModel MembersClientsNotInProject(AppDbContext db, Project project);
    }
}