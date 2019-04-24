using KolokwiumNr1.DAL;
using KolokwiumNr1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainWindow()
        {
            InitializeComponent();
            SetDataGrid();
            SetComboBox();
        }

        public void SetDataGrid()
        {
            var l = new DB().GetEmps();
            var resoult = from emp in l
                          select emp;

            DataGrid.ItemsSource = resoult;
        }

        public void SetComboBox()
        {
            var list = new DB().GetDepts();
            ComboBox.Items.Clear();
            foreach (DEPT d in list)
            {
                ComboBox.Items.Add(d.DNAME);
            }
            if (list.Count > 0)
            {
                ComboBox.SelectedItem = list[0].DNAME;
            }

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var resoult = from emp in new DB().GetEmps()
                          where emp.ENAME.StartsWith(Text3.Text)
                          select emp;

            DataGrid.ItemsSource=resoult;
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
            if (String.IsNullOrWhiteSpace(Text2.Text))
            {
                i++;
                Text2.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text2.BorderBrush = new SolidColorBrush(Colors.Black);
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
                var deptno = (from d in new DB().GetDepts()
                               where d.DNAME == ComboBox.Text
                               select d.DEPTNO).SingleOrDefault();
                
                var newEMP = new EMP
                {
                    EMPNO=0,
                    ENAME = Text1.Text,
                    JOB=Text2.Text,
                    DEPTNO=deptno
                };

                new DB().AddEmp(newEMP);
                
                Text1.Text = "";
                Text2.Text = "";

                SetComboBox();
                SetDataGrid();
            }

        }

    }
}


