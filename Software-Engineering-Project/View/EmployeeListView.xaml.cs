using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Software_Engineering_Project.View
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : Window
    {
        private readonly IUserService _userService = new UserService();

        private List<EmployeesListModel> _employees = new List<EmployeesListModel>();
        private readonly int _userId;

        public EmployeeListView(int userId)
        {
            InitializeComponent();
            _userId = userId;
            SetUserData();
            InitializeEmployeesList();
        }


        private async void InitializeEmployeesList()
        {
            await SetEmployeesList();
            employeeCountTextBlock.Text = _employees.Count.ToString();
            SetGrid();
        }


        // Adds all users to _employees
        private async Task SetEmployeesList()
        {
            _employees.Clear();

            foreach (var employee in await _userService.GetEmployeesList())
            {
                _employees.Add(employee);
            }
        }


        // Adds users to _employees based on search 
        private async Task SetEmployeesListBySearch(string searchText)
        {
            _employees.Clear();

            var employees = await _userService.GetEmployeesList();
            var searchResult = employees.Where(e => e.Fullname.ToLower().Contains(searchText.ToLower())).ToList();

            searchResult.ForEach(x => _employees.Add(x));
        }


        public async void SetUserData()
        {

            var user = await _userService.GetUser(_userId);
            userNameTextBlock.Text = user.FullName;
            if (user.IsBusinessOwner)
            {
                userStatusTextBlock.Text = "Business Owner";
            }
            else
            {
                userStatusTextBlock.Text = "Employee";
            }
        }


        private void SetGrid()
        {
            foreach (var e in _employees)
            {
                Grid grid = new Grid();
                grid.Height = 88;

                ColumnDefinition columnDefinition1 = new ColumnDefinition();
                ColumnDefinition columnDefinition2 = new ColumnDefinition();
                ColumnDefinition columnDefinition3 = new ColumnDefinition();
                ColumnDefinition columnDefinition4 = new ColumnDefinition();
                ColumnDefinition columnDefinition5 = new ColumnDefinition();
                ColumnDefinition columnDefinition6 = new ColumnDefinition();

                grid.ColumnDefinitions.Add(columnDefinition1);
                grid.ColumnDefinitions.Add(columnDefinition2);
                grid.ColumnDefinitions.Add(columnDefinition3);
                grid.ColumnDefinitions.Add(columnDefinition4);
                grid.ColumnDefinitions.Add(columnDefinition5);
                grid.ColumnDefinitions.Add(columnDefinition6);

                RowDefinition rowDefinition1 = new RowDefinition();

                grid.RowDefinitions.Add(rowDefinition1);


                TextBlock fullnameTextBlock = new TextBlock();
                fullnameTextBlock.Text = e.Fullname;
                fullnameTextBlock.VerticalAlignment = VerticalAlignment.Center;
                fullnameTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                fullnameTextBlock.Margin = new Thickness(20, 0, 0, 0);
                fullnameTextBlock.TextWrapping = TextWrapping.Wrap;
                fullnameTextBlock.FontSize = 14;
                fullnameTextBlock.FontWeight = FontWeights.Light;
                fullnameTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                fullnameTextBlock.Height = 17;
                fullnameTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(fullnameTextBlock, 0);
                Grid.SetRow(fullnameTextBlock, 0);


                TextBlock emailTextBlock = new TextBlock();
                emailTextBlock.Text = e.Email;
                emailTextBlock.VerticalAlignment = VerticalAlignment.Center;
                emailTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                emailTextBlock.Margin = new Thickness(20, 0, 0, 0);
                emailTextBlock.TextWrapping = TextWrapping.Wrap;
                emailTextBlock.FontSize = 14;
                emailTextBlock.FontWeight = FontWeights.Light;
                emailTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                emailTextBlock.Height = 17;
                emailTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(emailTextBlock, 1);
                Grid.SetRow(emailTextBlock, 0);


                TextBlock projectTextBlock = new TextBlock();
                projectTextBlock.Text = e.Project;
                projectTextBlock.VerticalAlignment = VerticalAlignment.Center;
                projectTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                projectTextBlock.Margin = new Thickness(20, 0, 0, 0);
                projectTextBlock.TextWrapping = TextWrapping.Wrap;
                projectTextBlock.FontSize = 14;
                projectTextBlock.FontWeight = FontWeights.Light;
                projectTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                projectTextBlock.Height = 17;
                projectTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(projectTextBlock, 2);
                Grid.SetRow(projectTextBlock, 0);


                TextBlock teamTextBlock = new TextBlock();
                teamTextBlock.Text = e.Team;
                teamTextBlock.VerticalAlignment = VerticalAlignment.Center;
                teamTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                teamTextBlock.Margin = new Thickness(20, 0, 0, 0);
                teamTextBlock.TextWrapping = TextWrapping.Wrap;
                teamTextBlock.FontSize = 14;
                teamTextBlock.FontWeight = FontWeights.Light;
                teamTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                teamTextBlock.Height = 17;
                teamTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(teamTextBlock, 3);
                Grid.SetRow(teamTextBlock, 0);


                TextBlock positionTextBlock = new TextBlock();
                positionTextBlock.Text = e.Position;
                positionTextBlock.VerticalAlignment = VerticalAlignment.Center;
                positionTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                positionTextBlock.Margin = new Thickness(20, 0, 0, 0);
                positionTextBlock.TextWrapping = TextWrapping.Wrap;
                positionTextBlock.FontSize = 14;
                positionTextBlock.FontWeight = FontWeights.Light;
                positionTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                positionTextBlock.Height = 17;
                positionTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(positionTextBlock, 4);
                Grid.SetRow(positionTextBlock, 0);


                TextBlock salaryTextBlock = new TextBlock();
                salaryTextBlock.Text = e.Salary.ToString() + "$";
                salaryTextBlock.VerticalAlignment = VerticalAlignment.Center;
                salaryTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                salaryTextBlock.Margin = new Thickness(20, 0, 0, 0);
                salaryTextBlock.TextWrapping = TextWrapping.Wrap;
                salaryTextBlock.FontSize = 14;
                salaryTextBlock.FontWeight = FontWeights.Light;
                salaryTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                salaryTextBlock.Height = 17;
                salaryTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(salaryTextBlock, 5);
                Grid.SetRow(salaryTextBlock, 0);


                grid.Children.Add(fullnameTextBlock);
                grid.Children.Add(emailTextBlock);
                grid.Children.Add(projectTextBlock);
                grid.Children.Add(teamTextBlock);
                grid.Children.Add(positionTextBlock);
                grid.Children.Add(salaryTextBlock);
                listStackPanel.Children.Add(grid);
            }


        }


        private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(searchTextBox.Text);
            listStackPanel.Children.Clear();
            await SetEmployeesListBySearch(searchTextBox.Text);
            SetGrid();
        }


        private void searchTextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (searchTextBox.Text == "Enter Fullname")
            {
                searchTextBox.Text = "";
            }
        }


        private void searchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ButtonSearch_Click(sender, e);
            }
        }
    }
}
