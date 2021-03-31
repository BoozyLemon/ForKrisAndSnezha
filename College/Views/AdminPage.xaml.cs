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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace College.Views
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            LoadEmployees();
            LoadStudents();
            LoadExams();
        }

        #region Employee

        private void LoadEmployees()
        {
            using (var db = new CollegeDB())
            {
                DataGridEmployees.ItemsSource = db.Employees.Include("Role").Include("EmployeeCategory").Where(x => x.IsFired != true).ToList();
            }
        }

        private void LoadEmployees(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                using (var db = new CollegeDB())
                {
                    DataGridEmployees.ItemsSource = db.Employees
                        .Include("Role")
                        .Include("EmployeeCategory")
                        .Where(x => x.IsFired != true)
                        .Where(c => (c.LastName + c.FirstName + c.MiddleName).ToLower().Contains(search.ToLower()))
                        .ToList();
                }
            }
            else
            {
                LoadEmployees();
            }
        }

        private void TextBoxSearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadEmployees(TextBoxSearchEmployee.Text);
        }

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            new AddEditEmployeeWindow().ShowDialog();
            LoadEmployees();
        }

        private void ButtonEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployees.SelectedIndex != -1)
            {
                var employeeId = (DataGridEmployees.SelectedItem as Employee).Id;
                new AddEditEmployeeWindow(employeeId).ShowDialog();
                LoadEmployees();
            }
        }

        private void ButtonFireEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployees.SelectedIndex != -1)
            {
                if (MessageBox.Show("Вы уверены, что хотите уволить сотрудника? Это действие нельзя будет отменить.", "Увольнение сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var employeeId = (DataGridEmployees.SelectedItem as Employee).Id;
                    using (var db = new CollegeDB())
                    {
                        db.Employees.Find(employeeId).IsFired = true;
                        db.SaveChanges();
                    }
                }
            }
            LoadEmployees();
        }

        #endregion

        #region Students

        public List<Student> Students { get; set; }
        public List<Student> BaseStudents { get; set; }
        private string search;
        private int genderId;

        private void LoadStudents()
        {
            using (var db = new CollegeDB())
            {
                BaseStudents = db.Students.Include("Gender").Include("Group").Where(x => x.IsExpelled != true).ToList();
            }
            SortStudents();
        }

        private void SortStudents()
        {
            if (BaseStudents != null)
            {
                Students = BaseStudents;
                if (!string.IsNullOrEmpty(search))
                {
                    Students = Students
                        .Where(c => (c.LastName + c.FirstName + c.MiddleName).ToLower().Contains(search.ToLower()))
                        .ToList();
                }
                if (genderId != -1)
                {

                    Students = Students.Where(x => x.GenderId == genderId).ToList();
                }
                if (ListViewStudents != null)
                {
                    ListViewStudents.ItemsSource = Students;
                }
            }
        }


        private void ButtonExpellStudent_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewStudents.SelectedIndex != -1)
            {
                if (MessageBox.Show("Вы уверены, что хотите отчислить студента? Это действие нельзя будет отменить.", "Отчисление студента", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var studentId = (ListViewStudents.SelectedItem as Student).Id;
                    using (var db = new CollegeDB())
                    {
                        db.Students.Find(studentId).IsExpelled = true;
                        db.SaveChanges();
                    }
                }
            }
            LoadStudents();
        }

        private void ButtonEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewStudents.SelectedIndex != -1)
            {
                var studentId = (ListViewStudents.SelectedItem as Student).Id;
                new AddEditStudentWindow(studentId).ShowDialog();
                LoadStudents();
            }
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            new AddEditStudentWindow().ShowDialog();
            LoadStudents();
        }

        private void TextBoxSearchStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            search = TextBoxSearchStudent.Text;
            SortStudents();
        }

        private void ComboBoxSortSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSortSex.SelectedIndex == 0)
            {
                genderId = -1;
            }
            else
            {
                genderId = ComboBoxSortSex.SelectedIndex;
            }
            SortStudents();
        }

        private void ListViewStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewStudents.SelectedIndex != -1)
            {
                var studentId = (ListViewStudents.SelectedItem as Student).Id;
                DetailsWindow window = new DetailsWindow(studentId);
                window.ShowDialog();
            }
        }

        #endregion

        #region Exams
        private void LoadExams()
        {

            using (var db = new CollegeDB())
            {
                ListViewExams.ItemsSource = db.Transcripts.ToList();
            }
            
        }
        private void ButtonAddExam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        #endregion
    }
}
