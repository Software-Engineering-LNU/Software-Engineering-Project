using DAL.Data;
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

        public async Task<bool> Contain(string email, string password)
        {
            bool contain = await _db.Users.AnyAsync(user => user.Email == email && user.Password == password);
            
            return contain;
        }
    }
}
