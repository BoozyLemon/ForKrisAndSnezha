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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(int studentId)
        {
            InitializeComponent();
            using (var db = new CollegeDB())
            {
                var student = db.Students.Include("Marks").First(x => x.Id == studentId);
                if (student.Photo != null)
                {
                    ImageStudent.Source = (BitmapSource)new ImageSourceConverter().ConvertFrom(student.Photo);
                }
                TextBlockName.Text = student.FullName;
                TextBlockGroupNumber.Text = student.GroupNumber;


                var semesters = db.Marks.Where(c => c.StudentId == studentId).ToList().Select(c => c.Transcript).ToList().Select(c => c.Subject.Semester).ToList();

                TabControlSemesters.ItemsSource = semesters;
            }
        }
    }
    public class CustomSemester
    {
        public Semester Semester { get; set; }
        public List<string> Marks { get => (List<string>)Semester.Subjects.Select(x => x.Transcripts.Select(c => c.Marks.Select(f => f.Overall.ToString()).ToList())); }
    }
}
