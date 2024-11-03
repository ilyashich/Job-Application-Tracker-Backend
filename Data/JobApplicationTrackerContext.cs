using JobApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Data;

public class JobApplicationTrackerContext : DbContext
{
    public JobApplicationTrackerContext(DbContextOptions<JobApplicationTrackerContext> options) : base(options){}

    public DbSet<User> Users { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Username = "Illia",
                PasswordHash = "123",
                Email = "illia@gmail.com",
                FirstName = "Illia",
                LastName = "Yatskevich",
            },
            new User
            {
                Username = "Alex",
                PasswordHash = "1234",
                Email = "alex@gmail.com",
                FirstName = "Alex",
                LastName = "Huts",
            }
        );
    }
}