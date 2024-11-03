using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("JobApplicationTrackerConnection");

builder.Services.AddDbContext<JobAppTrackerContext>(options =>
    options.UseMySQL(connectionString!)
);

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<JobAppTrackerContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
