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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }
        
        public MenuWindow(int userId)
        {
            InitializeComponent();
        }

        public MenuWindow(int userId, int roleId)
        {
            InitializeComponent();
            switch (roleId)
            {
                case 1:
                    MainFrame.Navigate(new AdminPage());
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}
