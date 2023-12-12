using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodiego.Data.Migrations;
using Foodiego.Interfaces;
using Foodiego.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodiego.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly FoodiegoDbContext Context;
        public UserRepository(FoodiegoDbContext context)
        {
            this.Context = context;
            
        }

        public async Task CreateAsync(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int UserId)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.UserId == UserId);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await Context.Users.ToListAsync();
        }
    }
}