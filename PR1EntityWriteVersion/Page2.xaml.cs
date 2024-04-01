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

namespace PR1EntityWriteVersion
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private THREntities customers = new THREntities();
        public Page2()
        {
            InitializeComponent();
            CustomersDataGrid.ItemsSource = customers.Customers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Customers d = new Customers();
            d.CustomerName = NameTbl.Text;
            d.CustomerSurename = NameTbl1.Text;
            d.CustomerMiddleName = NameTbl2.Text;
            d.CustomerCard = NameTbl3.Text;
            d.CustomerNumberOfPhone = NameTbl4.Text;
            
            customers.Customers.Add(d);
            customers.SaveChanges();
            CustomersDataGrid.ItemsSource = customers.Customers.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem != null)
            {
                var selected = CustomersDataGrid.SelectedItem as Customers;
                selected.CustomerName = NameTbl.Text;
                selected.CustomerSurename= NameTbl1.Text;
                selected.CustomerMiddleName= NameTbl2.Text;
                selected.CustomerCard = NameTbl3.Text;
                selected.CustomerNumberOfPhone= NameTbl4.Text;
                customers.SaveChanges();
                CustomersDataGrid.ItemsSource = customers.Customers.ToList();
            }
        }

       private void Button_Click_2(object sender, RoutedEventArgs e)
       {
            if (CustomersDataGrid.SelectedItem != null)
            {
                customers.Customers.Remove(CustomersDataGrid.SelectedItem as Customers);
                customers.SaveChanges();
                CustomersDataGrid.ItemsSource = customers.Customers.ToList();
            }
        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = CustomersDataGrid.SelectedItem as Customers;
            if (selected != null)
            {
                NameTbl.Text = selected.CustomerName.ToString();
                NameTbl1.Text = selected.CustomerSurename.ToString();
                NameTbl2.Text = selected.CustomerCard.ToString();
                NameTbl3.Text = selected.CustomerNumberOfPhone.ToString();
                customers.SaveChanges();
                CustomersDataGrid.ItemsSource = customers.Customers.ToList();
            }
        }

    }
}
