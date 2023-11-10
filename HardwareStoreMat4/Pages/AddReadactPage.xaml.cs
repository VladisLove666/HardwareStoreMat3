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
using Microsoft.Win32;
using HardwareStoreMat4.Components;
using System.IO;
using System.ComponentModel;

namespace HardwareStoreMat4.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddReadactPage.xaml
    /// </summary>
    public partial class AddReadactPage : Page
    {
        private Service service;
        public AddReadactPage(Service _service)
        {
            InitializeComponent();
            App.servicePage = this;
            service = _service;
            this.DataContext = service;
            RefreshPhoto();

        }

        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jng|*.jpeg|*.jpeg"
            };
            if(openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes
                    (openFile.FileName);
                KursImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if(service.ID == 0)
            {
                if(App.db.Service.Any(x => x.Title == service.Title))
                {
                    error.AppendLine("Такая услга уже существует");
                }
                else
                {
                  App.db.Service.Add(service);
                }
            }
            if (service.DurationInSeconds > 14400)
            {
                error.AppendLine("Длительность  не может привышать больше 4 часов");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                App.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
            }

        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0])))
            {
                e.Handled = true;
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jng|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto
                {
                    ServiceID = service.ID,
                    PhotoByte =  File.ReadAllBytes(openFile.FileName)
                });
                App.db.SaveChanges();
                RefreshPhoto();

            }
        }
        public void RefreshPhoto()
        {
            PhotoWp.Children.Clear();
            foreach (var photo in service.ServicePhoto)
            {
                PhotoWp.Children.Add(new PhotoUserControl(photo));
            }
            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream byteStream = new MemoryStream(service.MainImage);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = byteStream;
            bitmapImage.EndInit();
            KursImage.Source = bitmapImage;
        }
    }
}
