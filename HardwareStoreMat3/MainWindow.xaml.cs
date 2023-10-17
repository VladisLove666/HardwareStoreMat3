﻿using HardwareStoreMat3.Components;
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
            Random random = new Random();
            var products = App.db.Product.ToList();
            foreach (var product in products)
            {
                ProductWrapPanel.Children.Add(
                    new ProductUserControl(
                    product.Title,
                    $"{product.AvgOcenka: 0.00}",
                    product.KolvoOtziv + " отзывов",
                    $"{product.Cost: 0.00}",
                    product.CostWithDiscount.ToString(),
                    product.CostVisiblity
                    )
                );
            }
        }
    }
}
