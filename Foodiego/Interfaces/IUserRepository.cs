using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodiego.DTO;
using Foodiego.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foodiego.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(UserDto userDto);
        Task<UserDto> GetUserAsync(int UserId);
        Task<IEnumerable<UserDto>> GetAllUserAsync();
        Task<IActionResult> UpdateUserAsync(int UserId, UserDto userDto);
        Task<IActionResult> DeleteUserAsync(int UserId, UserDto userDto);
    }
}