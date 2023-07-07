using Project.DAO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace Project.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserDAO dao = new UserDAO();
            string password = tbPassword.Password; // Lấy giá trị text của PasswordBox
            User user = dao.getUserByUsernameAndPassword(tbUsername.Text, password);
            if (user != null)
            {
                Account.UserName = user.UserName;
                Account.Image =user.Image;
                // Redirect to the main application window or perform any other action
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the login window
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
