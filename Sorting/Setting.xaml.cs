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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Setting(object sender, RoutedEventArgs e)
        {
            Int64.TryParse(Last.Text, out MainWindow.last);
            Int64.TryParse(First.Text, out MainWindow.first);
            if (save.IsChecked == true)
                MainWindow.SaveFiles = true;
            else
                MainWindow.SaveFiles = false;
            Properties.Settings.Default.Save_to_disk = MainWindow.SaveFiles;
            if (Languages.SelectedIndex == 0)
            {
                MainWindow.Labels = MainWindow.ArLabels;
                Properties.Settings.Default.Languages = false;
            }
            else
            {
                MainWindow.Labels = MainWindow.EnLabels;
                Properties.Settings.Default.Languages = true;
            }
            Properties.Settings.Default.Last = MainWindow.last;
            Properties.Settings.Default.First = MainWindow.first;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Last.Text = MainWindow.last.ToString();
            First.Text = MainWindow.first.ToString();
            save.IsChecked = MainWindow.SaveFiles;
            this.Title = MainWindow.Labels[20];
            save.Content = MainWindow.Labels[21];
            Label1.Content = MainWindow.Labels[22];
            Label2.Content = MainWindow.Labels[23];
            Label3.Content = MainWindow.Labels[24];
            Label4.Content = MainWindow.Labels[25];
            Save_Set.Content = MainWindow.Labels[26];
            Cancel1.Content = MainWindow.Labels[27];
            Default.Content = MainWindow.Labels[48];
            if (MainWindow.Labels[0][0].Equals('S'))
            {
                this.FlowDirection = FlowDirection.LeftToRight;
                Languages.SelectedIndex = 1;
            }
            else
            {
                this.FlowDirection = FlowDirection.RightToLeft;
                Languages.SelectedIndex = 0;
            }
        }

        private void Default_Setting(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            MainWindow.last = Properties.Settings.Default.Last;
            Last.Text = Properties.Settings.Default.Last.ToString();
            MainWindow.first = Properties.Settings.Default.First;
            First.Text = Properties.Settings.Default.First.ToString();
            save.IsChecked = MainWindow.SaveFiles = Properties.Settings.Default.Save_to_disk;
            if (Properties.Settings.Default.Languages)
            {
                MainWindow.Labels = MainWindow.EnLabels;
                Languages.SelectedIndex = 1;
            }
            else
            {
                MainWindow.Labels = MainWindow.ArLabels;
                Languages.SelectedIndex = 0;
            }
            this.Close();
        }
    }
}
