using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> getListOfProjectsByUserId(int id);
        Task<Project> GetProjectById(int id);
    }
}
