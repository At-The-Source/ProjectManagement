using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Common;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Persistence
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specifies to modelbuilder how the database should be constructed (using Configurations folder)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectManagementDbContext).Assembly);

            // Dummy data added on migration.

            // Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = Guid.Parse("a29b4825-4b8e-477a-8849-e07a3c74d593"),
                    ProjectName = "TestProject 1",
                    Description = "This is first test project."
                });
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = Guid.Parse("33affb1e-06a8-4524-a2ce-544c81024372"),
                    ProjectName = "TestProject 2",
                    Description = "This is second test project."
                });

            // Tasks
            modelBuilder.Entity<Domain.Entities.Task>().HasData(
                new Domain.Entities.Task
                {
                    TaskId = Guid.Parse("510e161f-7e06-4f6a-bf11-ee03c3d526b2"),
                    TaskName = "TestTask 1",
                    Description = "Do test stuff 1.",
                    StartDate = DateTime.Now.AddDays(2),
                    StopDate = DateTime.Now.AddDays(20)
                });
            modelBuilder.Entity<Domain.Entities.Task>().HasData(
                new Domain.Entities.Task
                {
                    TaskId = Guid.Parse("2860415c-a070-4ded-bc9f-5e51e5c60d02"),
                    TaskName = "TestTask 2",
                    Description = "Do test stuff 2.",
                    StartDate = DateTime.Now.AddDays(8),
                    StopDate = DateTime.Now.AddDays(10)
                });

            // Users
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = Guid.Parse("1ac53c26-e3a6-431b-a747-41a7cc167797"),
                    UserName = "TestUser1",
                    FirstName = "Testar",
                    LastName = "Testsson"
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = Guid.Parse("e413b116-5b9b-4283-a025-c1ff9dc59392"),
                    UserName = "TestUser2",
                    FirstName = "Thomas",
                    LastName = "Karlsson"
                });
        }


        // Save properties for the AuditableEntity in db when saving (for logging purpose)
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    // If entity added, set date
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    // If entity changed, set date
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
