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
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        private readonly IUserService _userService = new UserService();
        private readonly string _email;

        public EditEmployeeWindow(string email)
        {
            InitializeComponent();
            _email = email;
        }


        private async void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            var user = await _userService.GetUserByEmail(_email);

            User newUser = new User
            {
                Id = user.Id,
                Email = emailTextBox.Text,
                Password = passwordTextBox.Text,
                FullName = fullnameTextBox.Text,
                PhoneNumber = phoneTextBox.Text,
                IsBusinessOwner = user.IsBusinessOwner,
                Projects = user.Projects,
                Tasks = user.Tasks
            };

            await _userService.UpdateUser(newUser);

            this.Close();
        }
    }
}
