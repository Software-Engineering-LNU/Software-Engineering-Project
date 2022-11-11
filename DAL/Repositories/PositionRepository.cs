using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DAL.Repositories
{
    public sealed class PositionRepository : IPositionRepository
    {
        private readonly EmployeestDbContext _db = new EmployeestDbContext();

        public async Task Add(Position position)
        {
            await _db.Positions.AddAsync(position);
            _db.SaveChanges();
        }
    }
}
