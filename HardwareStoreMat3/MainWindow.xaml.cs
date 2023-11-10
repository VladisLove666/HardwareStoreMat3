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
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Product> products = App.db.Product;
            switch (SortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    products = products.OrderBy(x => x.CostWithDiscount);
                    break;
                case 2:
                    products = products.OrderByDescending(x => x.CostWithDiscount);
                    break;
            }

            switch (DiscountFilterCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    products = products.Where(x => x.Discount >= 0 && x.Discount < 0.05);
                    break;
                case 2:
                    products = products.Where(x => x.Discount >= 0.05 && x.Discount < 0.15);
                    break;
                case 3:
                    products = products.Where(x => x.Discount >= 0.15 && x.Discount < 0.30);
                    break;
                case 4:
                    products = products.Where(x => x.Discount >= 0.30 && x.Discount < 0.70);
                    break;
                case 5:
                    products = products.Where(x => x.Discount >= 0.70 && x.Discount < 0.100);
                    break;
            }

            string searchText = SearchTb.Text.ToLower();
            if (searchText != "")
            {
                products = products.Where(x => x.Title.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText));
            }

            ProductWrapPanel.Children.Clear();
            foreach (var product in products)
            {
                ProductWrapPanel.Children.Add(
                    new ProductUserControl(product)
                );
            }
            KolvoProductovTb.Text = products.Count() + " из " + App.db.Product.Count();


        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
