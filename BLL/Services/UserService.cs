using BLL.Interfaces;
using DAL.Entities;
using System;
using BLL.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BLL.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        public async Task<bool> Login(string email, string password)
        {
            bool status = await _unitOfWork.UserRepository.Contain(email, password);
            return status;
        }
    }
}
