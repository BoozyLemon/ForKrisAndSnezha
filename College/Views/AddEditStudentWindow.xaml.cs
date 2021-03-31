using College.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        public AddEditStudentWindow()
        {
            InitializeComponent(); using (var db = new CollegeDB())
            {

                ComboBoxGender.ItemsSource = db.Genders.ToList();
                ComboBoxGroup.ItemsSource = db.Groups.ToList();
            }
        }

        public AddEditStudentWindow(int studentId)
        {
            InitializeComponent();
            StudentId = studentId;
            using (var db = new CollegeDB())
            {
                ComboBoxGender.ItemsSource = db.Genders.ToList();
                ComboBoxGroup.ItemsSource = db.Groups.ToList();
                var student = db.Students.Find(studentId);
                if (student.Photo != null)
                {
                    ImageStudent.Source = (BitmapSource)new ImageSourceConverter().ConvertFrom(student.Photo);
                }
                TextBoxLastName.Text = student.LastName;
                TextBoxFirstName.Text = student.FirstName;
                TextBoxMiddleName.Text = student.MiddleName;
                TextBoxLogin.Text = student.Login;
                PasseordBoxPas.Password = student.Password;
                DatePickerBirthDate.SelectedDate = (DateTime)student.BirthDate;
                TextBoxAddress.Text = student.Adrress;
                ComboBoxGender.SelectedIndex = student.GenderId - 1;
                ComboBoxGroup.SelectedIndex = student.GroupId - 1;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files | *.jpg; *.jpeg; *.png";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {

                ImageStudent.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                imagePath = openFileDialog.FileName;
            }
        }
        private string imagePath;

        public int StudentId { get; }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (StudentId > 0)
            {
                using (var db = new CollegeDB())
                {
                    var student = db.Students.Find(StudentId);
                    if (imagePath != "")
                    {
                        student.Photo = File.ReadAllBytes(imagePath);
                    }
                    student.LastName = TextBoxLastName.Text;
                    student.FirstName = TextBoxFirstName.Text;
                    student.MiddleName = TextBoxMiddleName.Text;
                    student.Login = TextBoxLogin.Text;
                    student.Password = PasseordBoxPas.Password;
                    student.BirthDate = (DateTime)DatePickerBirthDate.SelectedDate;
                    student.Adrress = TextBoxAddress.Text;
                    student.GenderId = ComboBoxGender.SelectedIndex + 1;
                    student.GroupId = ComboBoxGroup.SelectedIndex + 1;
                    db.SaveChanges();
                    Close();
                }
            }
            else
            {
                using (var db = new CollegeDB())
                {
                    var student = new Student();
                    if (File.Exists(imagePath))
                    {
                        student.Photo = File.ReadAllBytes(imagePath);
                    }
                    student.LastName = TextBoxLastName.Text;
                    student.FirstName = TextBoxFirstName.Text;
                    student.MiddleName = TextBoxMiddleName.Text;
                    student.Login = TextBoxLogin.Text;
                    student.Password = PasseordBoxPas.Password;
                    student.BirthDate = (DateTime)DatePickerBirthDate.SelectedDate;
                    student.Adrress = TextBoxAddress.Text;
                    student.GenderId = ComboBoxGender.SelectedIndex + 1;
                    student.GroupId = ComboBoxGroup.SelectedIndex + 1;
                    db.Students.Add(student);
                    db.SaveChanges();
                    Close();
                }
            }
        }
    }
}
