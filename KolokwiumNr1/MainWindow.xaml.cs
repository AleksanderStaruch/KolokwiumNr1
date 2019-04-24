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

namespace KolokwiumNr1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Emp> list;
        public MainWindow()
        {
            InitializeComponent();
            SetDataGrid();
            SetComboBox();
        }

        public void SetDataGrid()
        {
            //DataGrid.Items.Clear();
            var l = new DB().GetEmps();
            var resoult = from emp in l
                          select emp;
            list = new ObservableCollection<Emp>(resoult.ToList());

            DataGrid.ItemsSource = list;
        }

        public void SetComboBox()
        {
            var list = new DB().GetDepts();
            ComboBox.Items.Clear();
            foreach (Dept s in list)
            {
                ComboBox.Items.Add(s.Name);
            }
            ComboBox.SelectedItem = list[0].Name;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var resoult = from emp in new DB().GetEmps()
                          where emp.Ename == Text3.Text
                          select emp;

            DataGrid.ItemsSource = resoult;
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = new DB().GetEmps();
        }

        public bool Check()
        {
            int i = 0;
            if (String.IsNullOrWhiteSpace(Text1.Text))
            {
                i++;
                Text1.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text1.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            if (String.IsNullOrWhiteSpace(Text1.Text))
            {
                i++;
                Text1.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text1.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            if (i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {






                Text1.Text = "";
                Text2.Text = "";
                //ComboBox

            }
            
        }

}
