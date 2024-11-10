using JobApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Data;

public class JobApplicationContext :DbContext
{
    public JobApplicationContext(DbContextOptions<JobApplicationContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userGuid = Guid.NewGuid();
        modelBuilder.Entity<User>().HasData(
            new User
            {
              Id  = userGuid,
              UserName = "illia",
              Email = "illia@gmail.com",
              PasswordHash = "$2a$11$ChChWKfnCukVSfypFdXcsukH9o.VRHn74Gi0BpdrZL0.3AZXrUhmy",
              FirstName = "Illia",
              LastName = "Yatskevich"
            },
            new User
            {
                Id  = Guid.NewGuid(),
                UserName = "alex",
                Email = "alex@gmail.com",
                PasswordHash = "$2a$11$aNprsJfhwKeeVpzYolfx8u4YuYnikDIgnkqkeeU3OtsKaIK55Jt1G",
                FirstName = "Alex",
                LastName = "Huts"
            }
        );

        modelBuilder.Entity<JobApplication>().HasData(
            new JobApplication
            {
                Id = Guid.NewGuid(),
                CompanyName = "Samsung",
                JobTitle = "Junior Java Developer",
                ApplicationDate = DateOnly.FromDateTime(DateTime.Now),
                JobApplicationStatus = JobApplicationStatus.Interview,
                JobPostingUrl = "https://www.samsung.com/careers",
                Notes = "Super cool job application",
                UserId = userGuid
            }
        );
    }
}