﻿using BLL.Interfaces;
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

        public async Task<int> Login(string email, string password)
        {
            int userId = await _unitOfWork.UserRepository.Contain(email, password);
            return userId;
        }
        public async Task<string> GetFullName(int id)
        {
            User user = await _unitOfWork.UserRepository.GetUser(id);
            return user.FullName;
        }
    }
}
