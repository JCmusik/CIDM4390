using System;
using Microsoft.EntityFrameworkCore;

namespace CodingClub.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<President> President { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPerson> ProjectPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<President>().ToTable("President");
            modelBuilder.Entity<Project>().ToTable("Project");

            modelBuilder.Entity<ProjectPerson>()
            .HasKey(mc => new { mc.PersonID, mc.ProjectID });

            modelBuilder.Entity<ProjectPerson>()
            .HasOne(p => p.Project)
            .WithMany(pr => pr.Persons)
            .HasForeignKey(id => id.ProjectID);

            modelBuilder.Entity<ProjectPerson>()
            .HasOne(pr => pr.Person)
            .WithMany(p => p.Projects)
            .HasForeignKey(id => id.PersonID);
        }

    }
}