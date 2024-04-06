﻿using Entities;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int userId, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
    }
}
