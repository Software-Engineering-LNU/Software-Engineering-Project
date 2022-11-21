using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for OwnerDashboardWindow.xaml
    /// </summary>
    public partial class OwnerDashboardWindow : Window
    {
        private readonly IUserService _userService = new UserService();
        private readonly IProjectService _projectService = new ProjectService();
        private static int _userId;

        public OwnerDashboardWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            setUserData();
            setUserProjectsData();
        }

        public async void setUserData()
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
            catch (Exception)
            {
                MessageBox.Show("Opps! Cannot connect to the server. Please, try again later", "Employeest", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async void setUserProjectsData()
        {
            var projects = await _projectService.getProjectsByUserId(_userId);
            ProjectsList.ItemsSource = projects;
        }
    }
}
