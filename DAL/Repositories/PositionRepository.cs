using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public async Task<Position> GetPositionById(int id)
        {
            return await _db.Positions.SingleAsync(x => x.Id == id);
        }
    }
}
