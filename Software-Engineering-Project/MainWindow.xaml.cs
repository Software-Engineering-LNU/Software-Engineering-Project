using System.Windows;
using EmployeestSeed;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmployeestSeed.Program.Run(); // Runs seeder
        }
    }
}