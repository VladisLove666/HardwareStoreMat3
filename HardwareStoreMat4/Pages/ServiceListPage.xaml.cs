using HardwareStoreMat4.Components;
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

namespace HardwareStoreMat4.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                AddBtn.Visibility = Visibility.Visible;
            }
            Refresh();
            
        }
        private void Refresh()
        {
            IEnumerable<Service> services = App.db.Service;
            if (SortPriceCb.SelectedIndex!= 0)
            {
                if (SortPriceCb.SelectedIndex == 1)
                    services = services.OrderBy(x => x.TotalCost);
                else
                    services = services.OrderByDescending(x => x.TotalCost);
            }
            if(SortDiscountCb.SelectedIndex!= 0)
            {
                switch(SortDiscountCb.SelectedIndex)
                {
                    case 1:
                        services = services.Where(x => x.Discount >= 0 && x.Discount < 5);
                        services = services.OrderBy(x => x.Discount);
                        break;
                    case 2:
                        services = services.Where(x => x.Discount >= 5 && x.Discount < 15);
                        services = services.OrderBy(x => x.Discount);
                        break;
                    case 3:
                        services = services.Where(x => x.Discount >= 15 && x.Discount < 30);
                        services = services.OrderBy(x => x.Discount);
                        break;
                   case 4:
                        services = services.Where(x => x.Discount >= 30 && x.Discount < 70);
                        services = services.OrderBy(x => x.Discount);
                        break;
                    case 5:
                        services = services.Where(x => x.Discount >= 70 && x.Discount < 100);
                        services = services.OrderBy(x => x.Discount);
                        break;
                }
           
            }
            if(SearchTb.Text != null)
            {
                services = services.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) || x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            }
            ServiceWrapPanel.Children.Clear();
            foreach (var service in services)
            {
                ServiceWrapPanel.Children.Add(new ServiceUserControl(service));
            }
            CountDateTb.Text = services.Count() + " из " + App.db.Service.Count();
        }
        private void SortPriceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortDiscountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Добавить", new AddReadactPage(new Service())));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Записи клиентов", new UpEnPage()));
        }
    }
}
