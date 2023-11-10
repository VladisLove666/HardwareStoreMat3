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

namespace HardwareStoreMat4.Components
{
    /// <summary>
    /// Логика взаимодействия для ReagPage.xaml
    /// </summary>
    public partial class ReagPage : Page
    {
        Service service;
        public ReagPage(Service _service)
        {
            InitializeComponent();
            service = _service; 
            this.DataContext = _service;
            ClientCb.ItemsSource = App.db.Client.ToList();
            ClientCb.DisplayMemberPath = "FullName";
            DateDp.DisplayDateStart = DateTime.Today;
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ClientCb.SelectedItem != null && DateDp.SelectedDate != null && StartTimeTb.Text != "")
            {
                
                var startDate = $"{DateDp.SelectedDate.Value.ToString("dd.MM.yyyy")} {StartTimeTb.Text}";
                if (DateTime.TryParse(startDate, out DateTime dateTimeStart))
                {
                    if (dateTimeStart > DateTime.Now)
                    {

                        var selectClient = ClientCb.SelectedItem as Client;
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = selectClient.ID, ServiceID = service.ID, StartTime = dateTimeStart
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Клиент записан");

                    }

                    else
                    {
                        MessageBox.Show("Время прошло!");
                    }
                
                }
                else
                    {
                        MessageBox.Show("Время введенно неверно!");
                    }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void StartTimeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DateTime.TryParse(StartTimeTb.Text, out DateTime resultTime))
            {
                EndTimeTb.Text = resultTime.AddSeconds(service.DurationInSeconds).ToShortTimeString();
            }
        }
    }
}
