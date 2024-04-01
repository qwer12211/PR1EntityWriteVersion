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
using System.Xml;

namespace PR1EntityWriteVersion
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private THREntities orders = new THREntities();
        public Page3()
        {
            InitializeComponent();
            OrdersDataGrid.ItemsSource = orders.Orders.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Orders q = new Orders();
            q.ID_Customer = Convert.ToInt32(NameTbl.Text);
            q.ID_Burger = Convert.ToInt32(NameTbl1.Text);

            orders.Orders.Add(q);
            orders.SaveChanges();
            OrdersDataGrid.ItemsSource = orders.Orders.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem != null)
            {
                var selected = OrdersDataGrid.SelectedItem as Orders;
                selected.ID_Customer = Convert.ToInt32(NameTbl.Text);
                selected.ID_Burger = Convert.ToInt32(NameTbl1.Text);
                orders.SaveChanges();
                OrdersDataGrid.ItemsSource = orders.Orders.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem != null)
            {
                orders.Orders.Remove(OrdersDataGrid.SelectedItem as Orders);
                orders.SaveChanges();
                OrdersDataGrid.ItemsSource = orders.Orders.ToList();
            }
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = OrdersDataGrid.SelectedItem as Orders;
            if (selected != null)
            {    NameTbl.Text = selected.ID_Customer.ToString();
                NameTbl1.Text = selected.ID_Burger.ToString();
                orders.SaveChanges();
                OrdersDataGrid.ItemsSource = orders.Orders.ToList();
            }
        }
    }
}
