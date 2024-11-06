using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Data;

public class JobApplicationContext :DbContext
{
    public JobApplicationContext(DbContextOptions<JobApplicationContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
}