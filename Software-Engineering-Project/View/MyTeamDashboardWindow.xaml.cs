using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Software_Engineering_Project.View
{
    /// <summary>
    /// Interaction logic for MyTeamDashboardWindow.xaml
    /// </summary>
    public partial class MyTeamDashboardWindow : Window
    {
        private readonly IUserService _userService = new UserService();

        private List<TeamListModel> _team = new List<TeamListModel>();
        private readonly int _userId;

        public MyTeamDashboardWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            InitializeTeamList();
        }


        private async void InitializeTeamList()
        {
            var users = await _userService.GetTeamListByUserId(_userId);

            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    _team.Add(user);
                }

                employeeCountTextBlock.Text = _team.Count.ToString();
                SetGrid();
            }
            else
            {
                teamTableStackPanel.Children.Clear();
                TextBlock warningTextBlock = new TextBlock();
                warningTextBlock.Text = "You have no team!";
                warningTextBlock.VerticalAlignment = VerticalAlignment.Center;
                warningTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                warningTextBlock.FontSize = 26;
                warningTextBlock.FontWeight = FontWeights.Light;
                warningTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                warningTextBlock.Height = 50;
                warningTextBlock.Foreground = Brushes.Black;
                teamTableStackPanel.Children.Add(warningTextBlock);
            }
        }


        private void SetGrid()
        {
            foreach (var user in _team)
            {
                Grid grid = new Grid();
                grid.Height = 88;

                ColumnDefinition columnDefinition1 = new ColumnDefinition();
                ColumnDefinition columnDefinition2 = new ColumnDefinition();
                ColumnDefinition columnDefinition3 = new ColumnDefinition();
                ColumnDefinition columnDefinition4 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(columnDefinition1);
                grid.ColumnDefinitions.Add(columnDefinition2);
                grid.ColumnDefinitions.Add(columnDefinition3);
                grid.ColumnDefinitions.Add(columnDefinition4);

                RowDefinition rowDefinition1 = new RowDefinition();
                grid.RowDefinitions.Add(rowDefinition1);


                TextBlock fullnameTextBlock = new TextBlock();
                fullnameTextBlock.Text = user.Fullname;
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
                emailTextBlock.Text = user.Email;
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
                projectTextBlock.Text = user.Project;
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


                TextBlock positionTextBlock = new TextBlock();
                positionTextBlock.Text = user.Position;
                positionTextBlock.VerticalAlignment = VerticalAlignment.Center;
                positionTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                positionTextBlock.Margin = new Thickness(20, 0, 0, 0);
                positionTextBlock.TextWrapping = TextWrapping.Wrap;
                positionTextBlock.FontSize = 14;
                positionTextBlock.FontWeight = FontWeights.Light;
                positionTextBlock.FontFamily = new System.Windows.Media.FontFamily("Roboto");
                positionTextBlock.Height = 17;
                positionTextBlock.Foreground = Brushes.Black;

                Grid.SetColumn(positionTextBlock, 3);
                Grid.SetRow(positionTextBlock, 0);


                grid.Children.Add(fullnameTextBlock);
                grid.Children.Add(emailTextBlock);
                grid.Children.Add(projectTextBlock);
                grid.Children.Add(positionTextBlock);
                listStackPanel.Children.Add(grid);
            }
        }
    }
}
