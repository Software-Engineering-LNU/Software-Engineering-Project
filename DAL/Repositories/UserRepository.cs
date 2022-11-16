﻿using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DAL.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly EmployeestDbContext _db = new EmployeestDbContext();

        public async Task<int> Contain(string email, string password)
        {
            User user = await _db.Users.SingleAsync(x => x.Email == email && x.Password == password);
            return user.Id;
        }
        public async Task<User> GetUser(int id)
        {
            try
            {
                User user = await _db.Users.SingleAsync(x => x.Id == id);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new User();
            }
        }
        public async Task AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            _db.SaveChanges();
        }
    }
}
