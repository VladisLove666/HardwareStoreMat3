using HardwareStoreMat4.Components;
using SchoolLanguage.Components;
using SchoolLanguage.Pages;
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

namespace HardwareStoreMat4
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
            //var path = @"C:\Users\222117\Desktop\";
            //foreach(var i in App.db.Service.ToArray())
            //{
            //    var fullPath = path + i.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    i.MainImage = imageByte;
            //}
            //App.db.SaveChanges();
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
        }

        private void DActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
            PassB.Clear();
            Navigation.ClearHistory();
        }

        private void ActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PassB.Password.ToString() == "0000")
            {
                App.isAdmin = true;
            }
            PassB.Clear();
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
            Navigation.ClearHistory();
        }



        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
