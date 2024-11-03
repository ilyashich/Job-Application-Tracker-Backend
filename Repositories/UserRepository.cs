using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Repositories;

public class UserRepository : IUserRepository
{
    private readonly JobAppTrackerContext _db;

    public UserRepository(JobAppTrackerContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ApplicationUser>> GetUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<ApplicationUser?> GetUserById(Guid userId)
    {
        return await _db.Users.FindAsync(userId);
    }

    public async Task<ApplicationUser?> GetUserByUsername(string username)
    {
        return await _db.Users.SingleOrDefaultAsync(user => user.UserName == username);  
    }

    public async Task<ApplicationUser> AddUser(ApplicationUser applicationUser)
    {
        await _db.Users.AddAsync(applicationUser);
        await _db.SaveChangesAsync();
        return applicationUser;
    }

    public async Task<ApplicationUser> UpdateUser(ApplicationUser applicationUser)
    {
        _db.Users.Update(applicationUser);
        await _db.SaveChangesAsync();
        return applicationUser;
    }

    public async Task<bool> UserExists(Guid userId)
    {
        return await _db.Users.AnyAsync(user => user.Id == userId);
    }
}