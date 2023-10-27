using HardwareStoreMat3.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareStoreMat3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShop322MatEntities1 db = new HardwareShop322MatEntities1();
        public static bool isAdmin = false;
    }
}
