using System;
using System.Collections.Generic;
using System.IO;
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
using HardwareStoreMat4.Pages;

namespace HardwareStoreMat4.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {
        Service service;
        public ServiceUserControl(Service _service)
        {
            
            InitializeComponent();
            service= _service;
            ColorBd.Background = service.DiscBr;
            CosTb.Text = service.Cost.ToString("0");
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.CostTime;
            SaleTb.Text = service.Saleviv;
            CosTb.Visibility = service.CostVisibility;
            SerImg.Source = GetImage(service.MainImage);
            if(App.isAdmin == false)
            {
                EntryBtn.Visibility = Visibility.Hidden;
                RedactBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
          
        }
       private BitmapImage GetImage(byte[] byteImage)
       {
            BitmapImage bitmapImg = new BitmapImage();
            try
            {
                if (service.MainImage!= null)
                {
                        MemoryStream byteStr = new MemoryStream(byteImage);
                        bitmapImg.BeginInit();
                        bitmapImg.StreamSource = byteStr;
                        bitmapImg.EndInit();
                }
                else
                {
                    bitmapImg = new BitmapImage(new Uri(@"\Resources\school_logo.png", UriKind.Relative));
                }
                        
            }
            catch
            {
                MessageBox.Show("Error");
            }
            return bitmapImg;
            
       }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(service.ClientService!=null)
            {
                MessageBox.Show("dont delete");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
            }
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактировать", new AddReadactPage(service)));
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Запись на услугу", new ReagPage(service)));
        }
    }
}
