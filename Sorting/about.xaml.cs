using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sorting
{
    /// <summary>
    /// Interaction logic for about.xaml
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Labels[0][0].Equals('S'))
            {
                this.FlowDirection = FlowDirection.LeftToRight;
                Label1.Content = "Sorting & Searching Algorithms";
                Label1.Margin = new Thickness(73, 132, 0, 0);
                Closes.Content = "Close";
            }
            else
            {
                this.FlowDirection = FlowDirection.RightToLeft;
                Label1.Content = "خوارزميات الترتيب والبحث";
                Label1.Margin = new Thickness(113, 132, 0, 0);
                Closes.Content = "أغلق";
            }
        }
    }
}
