﻿using JobApplicationTracker.Models;

namespace JobApplicationTracker.Repositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(Guid id);
    Task<User?> GetByUsername(string userName);
}