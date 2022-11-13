using System.Threading.Tasks;
using System.Windows;
using BLL.Interfaces;
using BLL.Services;
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
            _userId = userId;
            setGreeting();
            //EmployeestSeed.Program.Run(); // Runs seeder

        }
        public async void setGreeting()
        {
            string fullname = await _userService.GetFullName(_userId);
            textBlockGreeting.Text = "Welcome, " + fullname;
        }

       
    }
}