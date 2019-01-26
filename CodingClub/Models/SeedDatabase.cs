using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodingClub.Models
{
    public class SeedDatabase
    {
        public static void Seed(IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetRequiredService<AppDbContext>();

            db.Database.EnsureCreated();

            if (!db.Projects.Any() && !db.Clients.Any() && !db.Members.Any() && !db.ProjectPersons.Any())
            {
                var projects = new List<Project>
                {
                    new Project
                    {
                        Title = "Kids Inc Webpage",
                        BeginDate = DateTime.Parse("12/14/2018"),
                        EndDate = DateTime.Parse("12/14/2019"),
                        TotalHours = 2000,

                    },
                    new Project
                    {
                        Title = "Palace Coffee Database",
                        BeginDate = DateTime.Parse("12/14/2018"),
                        EndDate = DateTime.Parse("6/14/2019"),
                        TotalHours = 1000,
                    }
                };

                var clients = new List<Client>
                {
                    new Client
                    {
                        FirstName = "Kids",
                        LastName = "Inc",
                        PhoneNumber = "806-376-5936",
                        Email = "info@kidsinc.org"
                    },
                    new Client
                    {
                        FirstName = "Palace",
                        LastName = "Coffee",
                        PhoneNumber = "806-476-0111",
                        Email = "info@palacecoffee.com"
                    },
                };

                var members = new List<Member>
                {
                    new Member
                    {
                        FirstName = "John",
                        LastName = "Cunningham",
                        PhoneNumber = "806-555-1111",
                        Email = "john@email.com"

                    },
                    new Member
                    {
                        FirstName = "Mara",
                        LastName = "Kinoff",
                        PhoneNumber = "806-555-1112",
                        Email = "mara@email.com"
                    },
                    new Member
                    {
                        FirstName = "Gabby",
                        LastName = "Cumbest",
                        PhoneNumber = "806-555-1113",
                        Email = "gabby@email.com"
                    },
                    new Member
                    {
                        FirstName = "Amy",
                        LastName = "Saysouriyosack",
                        PhoneNumber = "806-555-1114",
                        Email = "amy@email.com"
                    },
                    new Member
                    {
                        FirstName = "Cesareo",
                        LastName = "Lona",
                        PhoneNumber = "806-555-1115",
                        Email = "cesar@email.com"
                    },
                    new Member
                    {
                        FirstName = "Michael",
                        LastName = "Matthews",
                        PhoneNumber = "806-555-1116",
                        Email = "michael@email.com"
                    },
                    new Member
                    {
                        FirstName = "Mason",
                        LastName = "McCollum",
                        PhoneNumber = "806-555-1117",
                        Email = "mason@email.com"
                    },
                    new Member
                    {
                        FirstName = "Catherine",
                        LastName = "McGovern",
                        PhoneNumber = "806-555-1118",
                        Email = "catherine@email.com"
                    },
                    new Member
                    {
                        FirstName = "Quan",
                        LastName = "Nyguyen",
                        PhoneNumber = "806-555-1119",
                        Email = "quan@email.com"
                    },
                    new Member
                    {
                        FirstName = "Vanessa",
                        LastName = "Valenzuela",
                        PhoneNumber = "806-555-1120",
                        Email = "vanessa@email.com"
                    }
                };

                var projpeople = new List<ProjectPerson>
                {
                    new ProjectPerson {ProjectID = projects[0].ProjectID,
                                        Project = projects[0],
                                        PersonID = clients[0].ID,
                                        Person = clients[0]
                                        },
                    new ProjectPerson {ProjectID = projects[1].ProjectID,
                                        Project = projects[1],
                                        PersonID = clients[1].ID,
                                        Person = clients[1]
                                        },
                    new ProjectPerson {ProjectID = projects[0].ProjectID,
                                        Project = projects[0],
                                        PersonID = members[0].ID,
                                        Person = members[0]
                                        },
                    new ProjectPerson {ProjectID = projects[0].ProjectID,
                                        Project = projects[0],
                                        PersonID = members[1].ID,
                                        Person = members[1]
                                        },
                    new ProjectPerson {ProjectID = projects[0].ProjectID,
                                        Project = projects[0],
                                        PersonID = members[2].ID,
                                        Person = members[2]
                                        },
                    new ProjectPerson {ProjectID = projects[0].ProjectID,
                                        Project = projects[0],
                                        PersonID = members[3].ID,
                                        Person = members[3]
                                        },
                    new ProjectPerson {ProjectID = projects[0].ProjectID,
                                        Project = projects[0],
                                        PersonID = members[4].ID,
                                        Person = members[4]
                                        },
                    new ProjectPerson {ProjectID = projects[1].ProjectID,
                                        Project = projects[1],
                                        PersonID = members[5].ID,
                                        Person = members[5]
                                        },
                    new ProjectPerson {ProjectID = projects[1].ProjectID,
                                        Project = projects[1],
                                        PersonID = members[6].ID,
                                        Person = members[6]
                                        },
                    new ProjectPerson {ProjectID = projects[1].ProjectID,
                                        Project = projects[1],
                                        PersonID = members[7].ID,
                                        Person = members[7]
                                        },
                    new ProjectPerson {ProjectID = projects[1].ProjectID,
                                        Project = projects[1],
                                        PersonID = members[8].ID,
                                        Person = members[8]
                                        },
                    new ProjectPerson {ProjectID = projects[1].ProjectID,
                                        Project = projects[1],
                                        PersonID = members[9].ID,
                                        Person = members[9]
                                        }

                };
                db.ProjectPersons.AddRange(projpeople);
                db.SaveChanges();
            }
            else
                return;  // database has already been seeded
        }
    }
}
