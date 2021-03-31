using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace College.Views
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            TextBoxLogin.Focus();
        }

        private void CheckBoxShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBoxPas.Password;
            TextBoxPassword.Visibility = Visibility.Visible;
            PasswordBoxPas.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBoxPas.Password = TextBoxPassword.Text;
            PasswordBoxPas.Visibility = Visibility.Visible;
            TextBoxPassword.Visibility = Visibility.Collapsed;
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            string password;
            if (PasswordBoxPas.Password.Length > 0)
            {
                password = PasswordBoxPas.Password;
            }
            else
            {
                password = TextBoxPassword.Text;
            }
            using (var db = new CollegeDB())
            {
                Employee employee = db.Employees.FirstOrDefault(c => c.Login == TextBoxLogin.Text && c.Password == password);
                Student student = db.Students.FirstOrDefault(c => c.Login == TextBoxLogin.Text && c.Password == password);
                if (employee != null)
                {
                    MenuWindow window = new MenuWindow(employee.Id, employee.RoleId);
                    window.Show();
                    Close();
                    MessageBox.Show("Здравствуйте, " + employee.FirstName + "!", "Авторизация прошла успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (student != null)
                {
                    MenuWindow window = new MenuWindow(student.Id);
                    window.Show();
                    Close();
                    MessageBox.Show("Здравствуйте, " + student.FirstName + "!", "Авторизация прошла успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
