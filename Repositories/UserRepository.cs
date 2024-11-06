using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Repositories;

public class UserRepository : IUserRepository
{
    private readonly JobApplicationContext _db;

    public UserRepository(JobApplicationContext db)
    {
        _db = db;
    }

    public async Task AddUser(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _db.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _db.Users.SingleOrDefaultAsync(user => user.UserId == id);
    }

    public async Task<User?> GetByUsername(string userName)
    {
        return await _db.Users.SingleOrDefaultAsync(user => user.UserName == userName);
    }
}