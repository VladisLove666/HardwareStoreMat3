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

namespace HardwareStoreMat3.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        Product product;
        public ProductUserControl(Product _product)
        {
            InitializeComponent();
            product = _product;
            TitleTb.Text = product.Title;
            OcenkaTb.Text = product.AvgOcenka.ToString();
            OtziviTb.Text = product.KolvoOtziv.ToString();
            CostTb.Text = product.Cost.ToString();
            CostWithDiscountTb.Text = product.CostWithDiscount;
            CostTb.Visibility = product.CostVisiblity;
        }
    }
}
