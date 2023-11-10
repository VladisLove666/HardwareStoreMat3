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
    /// Логика взаимодействия для UpEnPage.xaml
    /// </summary>
    public partial class UpEnPage : Page
    {
        DateTime endDate = DateTime.Today.AddDays(2);
        public UpEnPage()
        {
            InitializeComponent();
            EntriesList.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x=>x.StartTime).ToList();
        }
    }
}
