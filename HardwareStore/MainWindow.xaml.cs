using HardwareStore.Components;
using HardwareStore.Pages;
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

namespace HardwareStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.mainWindow = this;
        }

        private void OnAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordPb.Password == "0000")
            {
                Navigation.ClearHistory();
                App.isAdmin = true;
                MessageBox.Show("Успешно");
                Navigation.NextPage(new PageComponent("Список услуг", new ServicesListPage()));


                PasswordPb.Clear();

            }
            else if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                MessageBox.Show("Введите пароль");

            }
            else if (PasswordPb.Password != "0000")
            {
                MessageBox.Show("Пароль неверный!");
                PasswordPb.Clear();
            }


        }

        private void OffAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.ClearHistory();
            App.isAdmin = false;
            MessageBox.Show("Отключение");
            Navigation.NextPage(new PageComponent("Список услуг", new ServicesListPage()));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
