using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HardwareStoreMat4.Components
{
    public partial class Service
    {
        public string CostTime
        {
            get
            {
                if (Discount == 0)
                    return $"{Cost:0} рублей за {DurationInSeconds / 60} минут";
                else
                    return $"  {Cost - (Cost * (decimal)Discount / 100):0} рублей за {DurationInSeconds / 60} минут";
            }
        }
        public string Saleviv
        {
            get { if (Discount != 0) return $"* скидка {Discount}%"; else return null; }
        }

        
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else 
                    return Visibility.Visible;
            }
        }

        public decimal TotalCost
        {
            get
            {
                if (Discount != 0) return Cost - (Cost * (decimal)Discount) / 100;
                else return Cost;
            }
        }
        public Brush DiscBr
        {
            get
            {
                if (Discount != 0)
                    return new SolidColorBrush(Colors.MediumSpringGreen);
                else return new SolidColorBrush(Colors.White);

                    

            }
        }
    }
}
