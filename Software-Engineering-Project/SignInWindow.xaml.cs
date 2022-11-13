using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private readonly IUserService _userService = new UserService();
        public SignInWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            labelErrorMessage.Visibility = Visibility.Hidden;
        }
        private void textBoxEmailTextChanged(object sender, TextChangedEventArgs args)
        {
            labelErrorMessage.Visibility = Visibility.Hidden;
        }
        private void passwordBoxPasswordTextChanged(object sender, RoutedEventArgs args)
        {
            labelErrorMessage.Visibility = Visibility.Hidden;
        }
        private bool isValidData()
        {
            if(!Regex.IsMatch(textBoxEmail.Text, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])"))
            {
                labelErrorMessage.Content = "Invalid email input";
                return false;
            }
            if(passwordBoxPassword.Password.Length < 9)
            {
                labelErrorMessage.Content = "Min length of password is 8";
                return false;
            }
            return true;
        }
        private async void buttonSignIn_Clicked(object sender, RoutedEventArgs e)
        {
            if(isValidData())
            {
                try
                {
                    int userId = await _userService.Login(textBoxEmail.Text, passwordBoxPassword.Password);
                    MainWindow mainWindow = new MainWindow(userId);
                    mainWindow.Show();
                    this.Close();
                    return;
                }
                catch (Exception exception)
                {
                    if (exception.Message == "Sequence contains no elements.")
                    {
                        labelErrorMessage.Content = "Invalid login or password";
                    }
                    else
                    {
                        MessageBox.Show("Opps! Cannot connect to the server. Please, try again later", "Employeest", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            labelErrorMessage.Visibility = Visibility.Visible;
        }
        private void buttonSignUp_Clicked(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }
    }
}
