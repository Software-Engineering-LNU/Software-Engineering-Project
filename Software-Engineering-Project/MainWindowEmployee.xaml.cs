using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Task = System.Threading.Tasks.Task;

namespace Software_Engineering_Project
{
    public partial class MainWindowEmployee : Window
    {
        private readonly IUserService _userService = new UserService();
        private readonly IEventService _eventService = new EventService();
        private readonly IProjectService _projectService = new ProjectService();
        private readonly ITeamService _teamService = new TeamService();
        private readonly ITaskService _taskService = new TasksService();
        private static int _userId;
        public MainWindowEmployee(int userId)
        {
            InitializeComponent();
            _userId = userId;
            setUserData();
            setUserEventsData();

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
            catch (Exception exception)
            {
                MessageBox.Show("Opps! Cannot connect to the server. Please, try again later", "Employeest", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async void setUserEventsData()
        {
            EventsList.ItemsSource = await _eventService.getEventsByUserId(_userId);
            var projects = await _projectService.getProjectsByUserId(_userId);
            ProjectsList.ItemsSource = projects;
            var teammates = await _teamService.getTeamMembersByUserId(_userId);
            TeamMatesList.ItemsSource = teammates;
            var tasks = await _taskService.getTasksByUserId(_userId);
            TasksList.ItemsSource = tasks;

            NumberOfProjects.Text = $"My projects [ {projects.Count} ]";
            NumberOfTeammates.Text = $"My teammates [ {teammates.Count} ]";
        }
    }
}