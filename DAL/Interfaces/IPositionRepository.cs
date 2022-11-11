using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DAL.Interfaces
{
    public interface IPositionRepository
    {
        Task Add(Position position);
    }
}
