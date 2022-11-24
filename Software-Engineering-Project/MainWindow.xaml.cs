using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Task = System.Threading.Tasks.Task;

namespace Software_Engineering_Project
{
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService = new UserService();
        private static int _userId;

        public MainWindow(int userId)
        {
            InitializeComponent();
            //EmployeestSeed.Program.Run(); // Runs seeder
            _userId = userId;
            SetUserData();
        }
        
        public async void SetUserData()
        {
            try
            {
                User user = await _userService.GetUser(_userId);
                textBlockGreeting.Text = "Welcome, " + user.FullName;
                textBlockUserName.Text = user.FullName;
                if (user.IsBusinessOwner)
                {
                    textBlockUserStatus.Text = "Business Owner";
                }
                else
                {
                    textBlockUserStatus.Text = "Employee";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Opps! Cannot connect to the server. Please, try again later", "Employeest", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}