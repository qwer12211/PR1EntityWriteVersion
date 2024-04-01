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
using System.Globalization;
using System.Diagnostics;

namespace PR1EntityWriteVersion
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private THREntities burgers = new THREntities();
        

        public Page1()
        {
            InitializeComponent();
            BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            Burgers c = new Burgers();
            c.BurgerName = NameTbl.Text;
            c.BurgerIngredient =  NameTbl1.Text;
                       
            decimal Sum;
            if(Decimal.TryParse(NameTbl2.Text, NumberStyles.AllowDecimalPoint, culture, out Sum))
            {
                c.BurgerSum = Sum;
                burgers.Burgers.Add(c);
                burgers.SaveChanges();
                BurgersDataGrid.ItemsSource = burgers.Burgers.ToList ();
            }
            decimal Name;
            if (Decimal.TryParse(NameTbl3.Text, NumberStyles.AllowDecimalPoint, culture, out Name))
            {
                c.BurgerWeight = Name;
                burgers.Burgers.Add(c);
                burgers.SaveChanges();
                BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();
            }
            decimal Lenght;
            if (Decimal.TryParse(NameTbl3.Text, NumberStyles.AllowDecimalPoint, culture, out Lenght))
            {
                c.BurgerLength = Lenght;
                burgers.Burgers.Add(c);
                burgers.SaveChanges();
                BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();
            }
            burgers.Burgers.Add(c);               
            burgers.SaveChanges();
            BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (BurgersDataGrid.SelectedItem != null)
            {
                var selected = BurgersDataGrid.SelectedItem as Burgers;
                if(selected !=null){
                    selected.BurgerName = NameTbl.Text;
                    selected.BurgerIngredient = NameTbl1.Text;
                    selected.BurgerSum = Convert.ToDecimal(NameTbl2.Text);
                    selected.BurgerWeight = Convert.ToDecimal(NameTbl3.Text);
                    selected.BurgerLength = Convert.ToDecimal(NameTbl4.Text);
                    burgers.SaveChanges();
                    BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();
                }                               
            }
        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (BurgersDataGrid.SelectedItem != null)
            {
                burgers.Burgers.Remove(BurgersDataGrid.SelectedItem as Burgers);
                burgers.SaveChanges();
                BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();
            }
        }

       

        private void BurgersDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (BurgersDataGrid.SelectedItem != null)
            {
                var selected = BurgersDataGrid.SelectedItem as Burgers;
                NameTbl.Text = selected.BurgerName.ToString();
                NameTbl1.Text = selected.BurgerIngredient.ToString();
                NameTbl2.Text = selected.BurgerSum.ToString();
                NameTbl3.Text = selected.BurgerWeight.ToString();
                NameTbl4.Text = selected.BurgerLength.ToString();
                burgers.SaveChanges();
                BurgersDataGrid.ItemsSource = burgers.Burgers.ToList();
            }
        }
    }
    
}
