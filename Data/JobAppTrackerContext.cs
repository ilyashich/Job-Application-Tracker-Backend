using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Data;

public class JobAppTrackerContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public JobAppTrackerContext(DbContextOptions<JobAppTrackerContext> options) : base(options){}
    public DbSet<JobApplication> JobApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}