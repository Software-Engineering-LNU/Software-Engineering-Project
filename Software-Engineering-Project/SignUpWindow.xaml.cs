using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private readonly IUserService _userService = new UserService();
        public SignUpWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            labelErrorMessage.Visibility = Visibility.Hidden;
        }
        private void textBoxFullNameTextChanged(object sender, TextChangedEventArgs args)
        {
            labelErrorMessage.Visibility = Visibility.Hidden;
        }
        private void textBoxPhoneNumberTextChanged(object sender, TextChangedEventArgs args)
        {
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
        private void passwordBoxConfirmPasswordTextChanged(object sender, RoutedEventArgs args)
        {
            labelErrorMessage.Visibility = Visibility.Hidden;
        }
        private bool isValidData()
        {
            if(!Regex.IsMatch(textBoxFullName.Text, "^[a-zA-Z]{4,}(?: [a-zA-Z]+){0,2}$"))
            {
                labelErrorMessage.Content = "Invalid full name input";
                return false;
            }
            if (!Regex.IsMatch(textBoxPhoneNumber.Text, "^((\\+38)?\\(?\\d{3}\\)?[\\s.-]?(\\d{7}|\\d{3}[\\s.-]\\d{2}[\\s.-]\\d{2}|\\d{3}-\\d{4}))"))
            {
                labelErrorMessage.Content = "Invalid phone number input";
                return false;
            }
            if (!Regex.IsMatch(textBoxEmail.Text, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])"))
            {
                labelErrorMessage.Content = "Invalid email input";
                return false;
            }
            if (passwordBoxPassword.Password.Length < 9)
            {
                labelErrorMessage.Content = "Min length of password is 8";
                return false;
            }
            if (passwordBoxPassword.Password != passwordBoxConfirmPassword.Password)
            {
                labelErrorMessage.Content = "Password don't match";
                return false;
            }
            return true;
        }
        private async void buttonSignUp_Clicked(object sender, RoutedEventArgs e)
        {
            if (isValidData())
            {
                try
                {
                    int userId = await _userService.Register(textBoxEmail.Text, passwordBoxPassword.Password, textBoxFullName.Text, textBoxPhoneNumber.Text, true);
                    User user = await _userService.GetUser(userId);
                    if(!user.IsBusinessOwner)
                    {
                        MainWindowEmployee mainWindow = new MainWindowEmployee(userId);
                        mainWindow.Show();
                    }
                    else
                    {
                        OwnerDashboardWindow mainWindow = new OwnerDashboardWindow(userId);
                        mainWindow.Show();
                    }
                    this.Close();
                    return;
                }
                catch(Exception exception)
                {
                    if (exception.Message == "An error occurred while saving the entity changes. See the inner exception for details.")
                    {
                        labelErrorMessage.Content = "This user already exist";
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
        private void buttonSignIn_Clicked(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
        }
    }
}
