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
    /// Interaction logic for AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        public AddEditEmployeeWindow()
        {
            InitializeComponent();
            using (var db = new CollegeDB())
            {
                ComboBoxCategory.ItemsSource = db.EmployeeCategories.ToList();
                ComboBoxRole.ItemsSource = db.Roles.ToList();
            }
        }

        public int EmployeeId { get; }

        public AddEditEmployeeWindow(int employeeId)
        {
            InitializeComponent();
            EmployeeId = employeeId;
            using (var db = new CollegeDB())
            {
                ComboBoxCategory.ItemsSource = db.EmployeeCategories.ToList();
                ComboBoxRole.ItemsSource = db.Roles.ToList();
                var employee = db.Employees.Find(employeeId);
                TextBoxLastName.Text = employee.LastName;
                TextBoxFirstName.Text = employee.FirstName;
                TextBoxMiddleName.Text = employee.MiddleName;
                TextBoxLogin.Text = employee.Login;
                PasseordBoxPas.Password = employee.Password;
                ComboBoxRole.SelectedIndex = employee.RoleId - 1;
                ComboBoxCategory.SelectedIndex = employee.CategoryId - 1;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что отменить действие? Введенные данные будут потеряны.", "Отмена", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeId > 0)
            {
                using (var db = new CollegeDB())
                {
                    var employee = db.Employees.Find(EmployeeId);
                    employee.LastName = TextBoxLastName.Text;
                    employee.FirstName =TextBoxFirstName.Text;
                    employee.MiddleName = TextBoxMiddleName.Text;
                    employee.Login = TextBoxLogin.Text;
                    employee.Password = PasseordBoxPas.Password;
                    employee.RoleId = ComboBoxRole.SelectedIndex + 1;
                    employee.CategoryId  = ComboBoxCategory.SelectedIndex + 1;
                    db.SaveChanges();
                    Close();
                }

            }
            else
            {
                using (var db = new CollegeDB())
                {
                    var employee = new Employee();
                    employee.LastName = TextBoxLastName.Text;
                    employee.FirstName = TextBoxFirstName.Text;
                    employee.MiddleName = TextBoxMiddleName.Text;
                    employee.Login = TextBoxLogin.Text;
                    employee.Password = PasseordBoxPas.Password;
                    employee.RoleId = ComboBoxRole.SelectedIndex + 1;
                    employee.CategoryId = ComboBoxCategory.SelectedIndex + 1;
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    Close();
                }
            }
        }
    }
}
