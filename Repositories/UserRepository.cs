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

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(Guid userId)
    {
        return await _db.Users.FindAsync(userId);
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _db.Users.SingleOrDefaultAsync(user => user.UserName == username);  
    }

    public async Task<User> AddUser(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UserExists(Guid userId)
    {
        return await _db.Users.AnyAsync(user => user.Id == userId);
    }
}