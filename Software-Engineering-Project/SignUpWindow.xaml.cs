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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
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
        private void buttonSignUp_Clicked(object sender, RoutedEventArgs e)
        {
            if (isValidData())
            {

            }
            else
            {
                labelErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
