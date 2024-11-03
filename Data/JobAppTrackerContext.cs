using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace JobApplicationTracker.Data;

public class JobAppTrackerContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public JobAppTrackerContext(DbContextOptions<JobAppTrackerContext> options) : base(options){}
    public DbSet<JobApplication> JobApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                UserName = "Illia",
                PasswordHash = "123",
                Email = "illia@gmail.com"
            },
            new ApplicationUser
            {
                UserName = "Alex",
                PasswordHash = "1234",
                Email = "alex@gmail.com"
            }
        );
    }
}