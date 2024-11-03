using JobApplicationTracker.Models;

namespace JobApplicationTracker.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetUsers();
    Task<ApplicationUser?> GetUserById(Guid userId);
    Task<ApplicationUser?> GetUserByUsername(string username);
    Task<ApplicationUser> AddUser(ApplicationUser applicationUser);
    Task<ApplicationUser> UpdateUser(ApplicationUser applicationUser);
    Task<bool> UserExists(Guid userId);
}