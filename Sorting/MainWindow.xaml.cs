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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;
using System.IO;

namespace Sorting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int n;
        int[] A = new int[0];
        public static long first = 0, last = 1000000000;
        bool BSflag = false;
        public static bool SaveFiles = false;
        bool ViewNumber = false;
        public static string[] ArLabels = { "خوارزميات الترتيب والبحث", "عدد الأرقام", "توليد أرقام عشوائية", "مجال الأرقام من (", ") حتى (", ")", "خوارزميات الترتيب", "خوارزميات البحث", "بحث عن:", "ترتيب بالاختيار", "ترتيب بالفقاعات", "ترتيب بالاقحام", "ترتيب بالدمج", "فرز سريع", "بحث خطي", "بحث ثنائي", "عرض الأعداد", "خيارات", "شرح البرنامج", "عن", "خيارات", "حفظ الأعداد المرتبة وغير المرتبة الى القرص الصلب.", "مجال الأعداد:", "من:", "الى:", "اللغة:", "حفظ", "الغاء", "لم تقم بتوليد أي رقم بعد!", "تم العمل خلال '", "' ميلي ثانية", "حفظ الارقام المرتبة", "حفظ الارقام الغير مرتبة", "تم", "مستند نصي ", "مربع البحث فارغ", "وجد في '", "' خلال '", "الرقم غير موجود\nزمن البحث '", "أولا يجب ترتيب الأعداد باحدى خوارزميات الترتيب", "عدد الارقام يجب ألا يتجاوز 2147483647", "عدد الارقام يجب أن يكون أكبر من 4", "البداية يجب ألا يتجاوز 2147483646", "رقم النهاية يجب ألا يتجاوز 2147483647", "البداية يجب أن يكون أكبر من 0", "النهاية يجب أن يكون أكبر من 1", "البداية يجب ان تكون أقل من النهاية", "تم الترتيب","الافتراضي" };
        public static string[] EnLabels = { "Sorting & Searching Algorithms ", "Numbers count ", "Generate Random Number ", "Nombers' domain from ( ", ") to ( ", ") ", "Sorting Algorithms ", "Searching Algorithms ", "Look for ", "Selection Sort ", "Bubble Sort ", "Insetion Sort ", "Merge Sort ", "Quick Sort ", "Linear Search ", "Binary Search ", "View Numbers ", "Setting ", "Help ", "about ", "Setting ", "Save numbers to your disk. ", "Numbers' domain: ", "From: ", "To: ", "Language: ", "Save ", "Cancel ", "You haven't generated any number yet! ", "Done in ' ", "' Millisecond ", "Save Sorted Numbers ", "Save Unsorted Numbers ", "Done ", "Text documents  ", "Search box is empty! ", "Found in ' ", "' in ' ", "Number not found\ntime ' ", "Number must be sorted before binary searching ", "Numbers mustn't be more than 2147483647 ", "Numbers mustn't be less than 4 ", "First number mustn't be more than 2147483646 ", "Last number mustn't be more than 2147483647 ", "First number mustn't be less than 0 ", "Last number mustn't be less than 1 ", "Last number must be greater than the first one ", "Sorted ", "Default" };
        public static string[] Labels;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (SaveFiles) Write(Labels[32]);
                int maxPos;
                int first = 0;
                long m1 = DateTime.Now.Ticks;
                while (first < n)
                {
                    maxPos = Min_Select(A, n, first);
                    Swap(A, maxPos, first);
                    first++;
                }
                long m2 = DateTime.Now.Ticks;
                long m = m2 - m1;
                MessageBox.Show(string.Concat(Labels[29], (((double)m) / 10000).ToString(), Labels[30]), Labels[47], MessageBoxButton.OK, MessageBoxImage.Information);
                if (SaveFiles) Write(Labels[31]);
                if (ViewNumber) viewNumber(true);
                BSflag = true;
            }
            else
                MessageBox.Show(Labels[28], Labels[9], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private int Min_Select(int[] A, int n, int first)
        {
            int maxPos = first;
            int CurrentPos = first + 1;
            while (CurrentPos < n)
            {
                if (A[CurrentPos] < A[maxPos])
                    maxPos = CurrentPos;
                CurrentPos++;
            }
            return maxPos;
        }

        private void Swap(int[] A, int first, int last)
        {
            int tmp = 0;
            tmp = A[last];
            A[last] = A[first];
            A[first] = tmp;
        }

        private void Bubble_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (SaveFiles) Write(Labels[32]);
                bool flag = true;
                long m1 = DateTime.Now.Ticks;
                for (int i = 0; (i < n) && flag; i++)
                {
                    flag = false;
                    for (int j = 0; j < n - 1; j++)
                        if (A[j] > A[j + 1])
                        {
                            Swap(A, j, j + 1);
                            flag = true;
                        }
                }
                long m2 = DateTime.Now.Ticks;
                long m = m2 - m1;
                MessageBox.Show(string.Concat(Labels[29], (((double)m) / 10000).ToString(), Labels[30]), Labels[47], MessageBoxButton.OK, MessageBoxImage.Information);
                if (SaveFiles) Write(Labels[31]);
                if (ViewNumber) viewNumber(true);
                BSflag = true;
            }
            else
                MessageBox.Show(Labels[28], Labels[10], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Write(string title)
        {
            Microsoft.Win32.SaveFileDialog SFD = new Microsoft.Win32.SaveFileDialog();
            StreamWriter SW;
            SFD.Title = title;
            SFD.Filter = Labels[34] + "(*.txt)|*.txt";
            if (SFD.ShowDialog() == true)
            {
                SW = new StreamWriter(SFD.FileName);
                for (int i = 0; i < n; i++)
                    SW.WriteLine(A[i]);
                SW.Close();
            }
        }

        private void Insetion_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                int tmp, k;
                if (SaveFiles) Write(Labels[32]);
                long m1 = DateTime.Now.Ticks;
                for (int i = 1; i < n; i++)
                {
                    k = i - 1;
                    tmp = A[i];
                    while (k > -1 && (A[k] > tmp))
                    {
                        A[k + 1] = A[k];
                        k = k - 1;
                    }
                    A[k + 1] = tmp;
                }
                long m2 = DateTime.Now.Ticks;
                long m = m2 - m1;
                MessageBox.Show(string.Concat(Labels[29], (((double)m) / 10000).ToString(), Labels[30]), Labels[47], MessageBoxButton.OK, MessageBoxImage.Information);
                if (SaveFiles) Write(Labels[31]);
                if (ViewNumber) viewNumber(true);
                BSflag = true;
            }
            else
                MessageBox.Show(Labels[28], Labels[11], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Merge_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (SaveFiles) Write(Labels[32]);
                long m1 = DateTime.Now.Ticks;
                Merge_Sort(A, 0, n - 1);
                long m2 = DateTime.Now.Ticks;
                long m = m2 - m1;
                MessageBox.Show(string.Concat(Labels[29], (((double)m) / 10000).ToString(), Labels[30]), Labels[47], MessageBoxButton.OK, MessageBoxImage.Information);
                if (SaveFiles) Write(Labels[31]);
                if (ViewNumber) viewNumber(true);
                BSflag = true;
            }
            else
                MessageBox.Show(Labels[28], Labels[12], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Merge_Sort(int[] A, int left, int right)
        {
            if (left < right)
            {
                int center = (left + right) / 2;
                Merge_Sort(A, left, center);
                Merge_Sort(A, center + 1, right);
                Merge(A, left, center, right);
            }
        }

        private void Merge(int[] A, int left, int center, int right)
        {
            int[] temp = new int[right - left + 1];
            int c = 0;
            int c1 = left;
            int c2 = center + 1;
            while ((c1 <= center) && (c2 <= right))
                if (A[c1] < A[c2])
                    temp[c++] = A[c1++];
                else
                    temp[c++] = A[c2++];
            while (c1 <= center)
                temp[c++] = A[c1++];
            while (c2 <= right)
                temp[c++] = A[c2++];
            for (int i = 0; i < right - left + 1; i++)
                A[left + i] = temp[i];
        }

        private void Rand1()
        {
            int tmp;
            Random rand = new Random((Int32)DateTime.Now.Ticks);
            for (int i = 0; i < (n / 4); i++)
            {
                tmp = rand.Next((Int32)first, (Int32)last);
                A[i] = tmp;
            }
        }

        private void Rand2()
        {
            int tmp;
            Random rand = new Random((Int32)(DateTime.Now.Ticks + 100000));
            for (int i = (n / 4); i < (n / 2); i++)
            {
                tmp = rand.Next((Int32)first, (Int32)last);
                A[i] = tmp;
            }
        }

        private void Rand3()
        {
            int tmp;
            Random rand = new Random((Int32)(DateTime.Now.Ticks + 9990000));
            for (int i = (n / 2); i < ((3 * n) / 4); i++)
            {
                tmp = rand.Next((Int32)first, (Int32)last);
                A[i] = tmp;
            }
        }

        private void Rand4()
        {
            int tmp;
            Random rand = new Random((Int32)(DateTime.Now.Ticks + 999999100000));
            for (int i = ((3 * n) / 4); i < n; i++)
            {
                tmp = rand.Next((Int32)first, (Int32)last);
                A[i] = tmp;
            }
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            if (Checker())
            {
                try
                {
                    BSflag = false;
                    int.TryParse(textBox3.Text, out n);
                    A = new int[n];
                    Thread t1 = new Thread(Rand1);
                    Thread t2 = new Thread(Rand2);
                    Thread t3 = new Thread(Rand3);
                    t1.Start();
                    t2.Start();
                    t3.Start();
                    Rand4();
                    MessageBox.Show(Labels[33], Labels[2], MessageBoxButton.OK, MessageBoxImage.Information);
                    if (ViewNumber) viewNumber(true);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("Exception of type 'System.OutOfMemoryException' was thrown."))
                        MessageBox.Show("Out of Memory.", Labels[2], MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show(ex.Message, Labels[2], MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Quick_Sort(int[] A, int left, int right)
        {
            int pivot;
            if (right > left)
            {
                pivot = Partition(A, left, right);
                Quick_Sort(A, left, pivot - 1);
                Quick_Sort(A, pivot + 1, right);
            }
        }

        private int Partition(int[] A, int left, int right)
        {
            int x, swapPos;
            int pivotPos = left + (right - left) / 2;
            Swap(A, left, pivotPos);
            swapPos = left + 1;
            for (int i = swapPos; i <= right; i++)
                if (A[i] < A[left])
                {
                    Swap(A, i, swapPos);
                    swapPos++;
                }
            x = A[left];
            A[left] = A[swapPos - 1]; A[swapPos - 1] = x;
            return swapPos - 1;
        }

        private void Quick_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (SaveFiles) Write(Labels[32]);
                long m1 = DateTime.Now.Ticks;
                Quick_Sort(A, 0, n - 1);
                long m2 = DateTime.Now.Ticks;
                long m = m2 - m1;
                MessageBox.Show(string.Concat(Labels[29], (((double)m) / 10000).ToString(), Labels[30]), Labels[47], MessageBoxButton.OK, MessageBoxImage.Information);
                if (SaveFiles) Write(Labels[31]);
                if (ViewNumber) viewNumber(true);
                BSflag = true;
            }
            else
                MessageBox.Show(Labels[28], Labels[13], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Linear_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (TextBox1.Text.Equals(string.Empty))
                    MessageBox.Show(Labels[35], Labels[14], MessageBoxButton.OK, MessageBoxImage.Stop);
                else
                {
                    int x, i;
                    int.TryParse(TextBox1.Text, out x);
                    long m1 = DateTime.Now.Ticks;
                    for (i = 0; i < n; i++)
                        if (A[i] == x)
                        {
                            long m2 = DateTime.Now.Ticks;
                            double m = m2 - m1;
                            if (ViewNumber && i > -1)
                            {
                                Numbers_List.SelectedIndex = i;
                                Numbers_List.ScrollIntoView(Numbers_List.SelectedItem);
                            }
                            MessageBox.Show(string.Concat(Labels[36], i + 1, Labels[37], (((double)m) / 10000).ToString(), Labels[30]), Labels[14], MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    if (i == n)
                    {
                        long m2 = DateTime.Now.Ticks;
                        long m = m2 - m1;
                        MessageBox.Show(string.Concat(Labels[38], (((double)m) / 10000).ToString(), Labels[30]), Labels[14], MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
                MessageBox.Show(Labels[28], Labels[14], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Binary_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (TextBox1.Text.Equals(string.Empty))
                    MessageBox.Show(Labels[35], Labels[15], MessageBoxButton.OK, MessageBoxImage.Stop);
                else
                {
                    if (BSflag == false)
                        MessageBox.Show(Labels[39], Labels[15], MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        int x, y;
                        int.TryParse(TextBox1.Text, out x);
                        long m1 = DateTime.Now.Ticks;
                        y = Binary_Search(n, x);
                        if (y == -1)
                        {
                            long m2 = DateTime.Now.Ticks;
                            long m = m2 - m1;
                            MessageBox.Show(string.Concat(Labels[38], (((double)m) / 10000).ToString(), Labels[30]), Labels[15], MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            long m2 = DateTime.Now.Ticks;
                            long m = m2 - m1;
                            if (ViewNumber && y > -1)
                            {
                                Numbers_List.SelectedIndex = y;
                                Numbers_List.ScrollIntoView(Numbers_List.SelectedItem);
                            }
                            MessageBox.Show(string.Concat(Labels[36], y + 1, Labels[37], (((double)m) / 10000).ToString(), Labels[30]), Labels[15], MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            else
                MessageBox.Show(Labels[28], Labels[15], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private int Binary_Search(int size, int target)
        {
            int first = 0;
            int last = size - 1;
            int mid = 0;
            bool found = false;
            while (first <= last && !found)
            {
                mid = (first + last) / 2;
                if (A[mid] == target)
                    found = true;
                else
                    if (A[mid] > target)
                        last = mid - 1;
                    else
                        first = mid + 1;
            }
            if (found) return mid;
            else return -1;
        }

        private bool Checker()
        {
            long count;
            long.TryParse(textBox3.Text, out count);
            if (count > 2147483647)
            { MessageBox.Show(Labels[40], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            if (count < 4)
            { MessageBox.Show(Labels[41], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            if (first > 2147483646)
            { MessageBox.Show(Labels[42], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            if (last > 2147483647)
            { MessageBox.Show(Labels[43], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            if (first < 0)
            { MessageBox.Show(Labels[44], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            if (last < 1)
            { MessageBox.Show(Labels[45], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            if (first >= last)
            { MessageBox.Show(Labels[46], Labels[2], MessageBoxButton.OK, MessageBoxImage.Error); return false; }
            return true;
        }

        void viewNumber(bool flag)
        {
            Numbers_List.Items.Clear();
            if (flag && A.Length > 0)
            {
                Numbers_List.Visibility = Visibility.Visible;
                foreach (int i in A)
                    Numbers_List.Items.Add(i);
                this.Width = 470;
            }
            else
            {
                Numbers_List.Visibility = Visibility.Collapsed;
                this.Width = 380;
            }
        }

        private void View_Number_Checked(object sender, RoutedEventArgs e)
        {
            ViewNumber = true;
            viewNumber(true);
        }

        private void View_Number_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewNumber = false;
            viewNumber(false);
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting window = new Setting();
            window.ShowDialog();
            Apply_Setting();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            about window = new about();
            window.ShowDialog();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            SaveFiles = Properties.Settings.Default.Save_to_disk;
            first = Properties.Settings.Default.First;
            last = Properties.Settings.Default.Last;
            if (Properties.Settings.Default.Languages)
                Labels = EnLabels;
            else
                Labels = ArLabels;
            Apply_Setting();
        }

        private void Apply_Setting()
        {
            this.Title = Labels[0];
            Label1.Content = Labels[1];
            Random.Content = Labels[2];
            info.Content = Labels[3] + first + Labels[4] + last + Labels[5];
            GroupBox1.Header = Labels[6];
            GroupBox2.Header = Labels[7];
            Label2.Content = Labels[8];
            Selection.Content = Labels[9];
            Bubble.Content = Labels[10];
            Insertion.Content = Labels[11];
            Marge.Content = Labels[12];
            Quick.Content = Labels[13];
            Linear.Content = Labels[14];
            Binary.Content = Labels[15];
            View_Number.Content = Labels[16];
            Setting.ToolTip = Labels[17];
            Help.ToolTip = Labels[18];
            about.ToolTip = Labels[19];
            if (Labels[0][0].Equals('S'))
                this.FlowDirection = FlowDirection.LeftToRight;
            else
                this.FlowDirection = FlowDirection.RightToLeft;
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (A.Length > 0)
            {
                if (SaveFiles) Write(Labels[32]);
                var list = A.ToList();
                long m1 = DateTime.Now.Ticks;
                list.Sort();
                long m2 = DateTime.Now.Ticks;
                A = list.ToArray();
                long m = m2 - m1;
                MessageBox.Show(string.Concat(Labels[29], (((double)m) / 10000).ToString(), Labels[30]), Labels[47], MessageBoxButton.OK, MessageBoxImage.Information);
                if (SaveFiles) Write(Labels[31]);
                if (ViewNumber) viewNumber(true);
                BSflag = true;
            }
            else
                MessageBox.Show(Labels[28], Labels[10], MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo PSI = new System.Diagnostics.ProcessStartInfo("Help.ppsx");
                System.Diagnostics.Process.Start(PSI);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}