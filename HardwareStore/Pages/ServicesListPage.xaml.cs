using HardwareStore.Components;
using HardwareStore.Components.PartialClass;
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

namespace HardwareStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesListPage.xaml
    /// </summary>
    public partial class ServicesListPage : Page
    {
        public ServicesListPage()
        {
            InitializeComponent();
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
                //EntriesBtn.Visibility = Visibility.Hidden;
            }
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Product> products = App.db.Product;
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    products = products.OrderBy(x => x.TotalCost);
                else
                    products = products.OrderByDescending(x => x.TotalCost);
            }
            if (DiscountFilterCb.SelectedIndex != 0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                    products = products.Where(x => x.Discount >= 0 && x.Discount < 5);
                if (DiscountFilterCb.SelectedIndex == 2)
                    products = products.Where(x => x.Discount >= 5 && x.Discount < 15);
                if (DiscountFilterCb.SelectedIndex == 3)
                    products = products.Where(x => x.Discount >= 15 && x.Discount < 30);
                if (DiscountFilterCb.SelectedIndex == 4)
                    products = products.Where(x => x.Discount >= 30 && x.Discount < 70);
                if (DiscountFilterCb.SelectedIndex == 5)
                    products = products.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
            if (SearchTb.Text != null)
            {
                products = products.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) || x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            ServiceWp.Children.Clear();
            foreach (var product in products)
            {
                ServiceWp.Children.Add(new ServiceUserControl(products));
            }
            CountDataTb.Text = products.Count() + " из " + App.db.Product.Count();
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
