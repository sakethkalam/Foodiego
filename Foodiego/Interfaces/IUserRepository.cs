using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodiego.Models;

namespace Foodiego.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> GetUserAsync(int UserId);
    }
}