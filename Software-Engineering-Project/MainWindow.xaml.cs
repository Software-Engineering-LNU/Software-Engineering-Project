using System.Threading.Tasks;
using System.Windows;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;

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
            //EmployeestSeed.Program.Run(); // Runs seeder

            
        }

       
    }
}