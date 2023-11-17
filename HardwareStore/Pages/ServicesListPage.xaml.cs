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
            IEnumerable<> services = App.db.Product;
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    services = services.OrderBy(x => x.TotalCost);
                else
                    services = services.OrderByDescending(x => x.TotalCost);
            }
            if (DiscountFilterCb.SelectedIndex != 0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                    services = services.Where(x => x.Discount >= 0 && x.Discount < 5);
                if (DiscountFilterCb.SelectedIndex == 2)
                    services = services.Where(x => x.Discount >= 5 && x.Discount < 15);
                if (DiscountFilterCb.SelectedIndex == 3)
                    services = services.Where(x => x.Discount >= 15 && x.Discount < 30);
                if (DiscountFilterCb.SelectedIndex == 4)
                    services = services.Where(x => x.Discount >= 30 && x.Discount < 70);
                if (DiscountFilterCb.SelectedIndex == 5)
                    services = services.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
