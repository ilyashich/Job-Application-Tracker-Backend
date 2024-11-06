using FluentValidation;
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using JobApplicationTracker.Repositories;
using JobApplicationTracker.Services;
using JobApplicationTracker.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("JobApplicationTrackerConnection");

builder.Services.AddDbContext<JobApplicationContext>(options =>
    options.UseMySQL(connectionString!)
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
