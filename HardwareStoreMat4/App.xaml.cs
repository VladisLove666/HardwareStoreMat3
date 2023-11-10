using HardwareStoreMat4.Components;
using SchoolLanguage.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareStoreMat4
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShop322MatEntities db = new HardwareShop322MatEntities();
        public static bool isAdmin = false;

        public static MainWindow mainWindow;
        public static AddReadactPage servicePage;
    }
}
