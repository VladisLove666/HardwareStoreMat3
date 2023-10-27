using HardwareStoreMat3.Components;
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
using System.IO;

namespace HardwareStoreMat3
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
            //var path = @"C:\Users\222114\Desktop\";
            //foreach (var item in App.db.Product.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImage = imageByte;
            //}
            //App.db.SaveChanges();
            Navigation.NextPage(new PageComponent("СУ", new ServiceListPage()));

        }


        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            Navigation.NextPage(new PageComponent("СУ", new ServiceListPage()));
            PassB.Clear();
            Navigation.ClearHistory();
        }

        private void ActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PassB.Password.ToString() == "1111")
            {
                App.isAdmin = true;
            }
            PassB.Clear();
            Navigation.NextPage(new PageComponent("СУ", new ServiceListPage()));
            Navigation.ClearHistory();
        }

        private void DActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
