using JobApplicationTracker.Data;
using JobApplicationTracker.Extensions;
using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("JobApplicationTrackerConnection");

builder.Services.AddDbContext<JobAppTrackerContext>(options =>
    options.UseMySQL(connectionString!)
);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<JobAppTrackerContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();

app.MapGroup("/api")
    .MapCustomIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
