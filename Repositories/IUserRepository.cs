using JobApplicationTracker.Models;

namespace JobApplicationTracker.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUserById(Guid userId);
    Task<User?> GetUserByUsername(string username);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<bool> UserExists(Guid userId);
}