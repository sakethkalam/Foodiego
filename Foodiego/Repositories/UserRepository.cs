using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Foodiego.Data.Migrations;
using Foodiego.DTO;
using Foodiego.Interfaces;
using Foodiego.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Foodiego.Repositories
{
    public class UserRepository : ControllerBase,IUserRepository
    {
        private readonly FoodiegoDbContext Context;
        private readonly ILogger<UserRepository> logger;
        public UserRepository(FoodiegoDbContext context)
        {
            this.Context = context;
            this.logger = logger;

        }

        [HttpPost]
        public async Task<User> CreateAsync(UserDto userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.EmailAddress,
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(userDto.Password),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Address = userDto.Address
            };
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();

            return user;
        }

        [HttpGet("{UserId}")]
        public async Task<UserDto> GetUserAsync(int UserId)
        {
            var user = await Context.Users.FindAsync(UserId);
            if (user != null)
            {
                return Mapper.Map<UserDto>(user);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            return await Context.Users.Select(user => new UserDto { UserName = user.UserName, EmailAddress = user.Email,FirstName = user.FirstName,LastName = user.LastName,PhoneNumber = user.PhoneNumber,Address = user.Address })
            .ToListAsync();
        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> UpdateUserAsync(int UserId, UserDto userDto)
        {   
            var user = await Context.Users.FindAsync(UserId);
            if (user == null)
            {
                return null;
            }
            
                user.UserName = userDto.UserName;
                user.Email = userDto.EmailAddress;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Address = userDto.Address;

                Context.Entry(user).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                logger.LogInformation($"User with ID {UserId} has been updated");
                return Ok(new {message=$"User with ID{UserId} has been updated"});
        }
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUserAsync(int UserId, UserDto userDto)
        {
            var user = await Context.Users.FindAsync(UserId);
            if(user == null)
            {
                return null;
            }

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            logger.LogInformation($"User with ID {UserId} has been removed");

            return Ok(new {message=$"User with ID{UserId} has been removed"});
        }
    }
}